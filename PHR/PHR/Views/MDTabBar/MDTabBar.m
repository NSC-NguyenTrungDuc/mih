// The MIT License (MIT)
//
// Copyright (c) 2015 FPT Software
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#import "MDTabBar.h"
#import "MDRippleLayer.h"
#import "UIColorHelper.h"
#import <uiKit/UISegmentedControl.h>
#import <Foundation/Foundation.h>
#import "UIFontHelper.h"

#define kMDContentHorizontalPaddingIPad 24
#define kMDContentHorizontalPaddingIPhone 12
#define kMDTabBarHorizontalInset 0

#define DISABLED_TEXT_ALPHA .6

@interface MDTabBar ()
@property (nonatomic) CGFloat tabBarHeight;
- (void)updateSelectedIndex:(NSInteger)selectedIndex;
@end

@implementation MDSegmentedControl {
    UIView *indicatorView;
    UIView *beingTouchedView;
    UIFont *font;
    MDTabBar *tabBar;
}

- (instancetype)initWithTabBar:(MDTabBar *)bar indicatorHeight:(float)indicatorHeight{
    if (self = [super init]) {
        _tabs = [NSMutableArray array];
        indicatorView = [[UIView alloc]
                         initWithFrame:CGRectMake(0, bar.bounds.size.height - indicatorHeight, 0,
                                                  indicatorHeight)];
        bar.tabBarHeight = bar.bounds.size.height;
        indicatorView.tag = NSIntegerMax;
        [self addSubview:indicatorView];
        [self addTarget:self
                 action:@selector(selectionChanged:)
       forControlEvents:UIControlEventValueChanged];
        tabBar = bar;
    }
    
    return self;
}

- (void)updateIndicatorHeight:(float)height{
    if (indicatorView) {
        CGRect frame = indicatorView.frame;
        frame.size.height = height;
        indicatorView.frame = frame;
    }
}

- (void)willMoveToSuperview:(UIView *)newSuperview {
    [super willMoveToSuperview:newSuperview];
    [newSuperview addObserver:self forKeyPath:@"frame" options:0 context:nil];
}

- (void)removeFromSuperview {
    [self.superview removeObserver:self forKeyPath:@"frame"];
    [super removeFromSuperview];
}

- (void)setSelectedSegmentIndex:(NSInteger)selectedSegmentIndex {
    [super setSelectedSegmentIndex:selectedSegmentIndex];
    [self moveIndicatorToSelectedIndexWithAnimated:YES];
}

- (void)selectionChanged:(id)sender {
    [self moveIndicatorToSelectedIndexWithAnimated:YES];
    [tabBar updateSelectedIndex:self.selectedSegmentIndex];
}

- (void)observeValueForKeyPath:(NSString *)keyPath
                      ofObject:(id)object
                        change:(NSDictionary *)change
                       context:(void *)context {
    if (object == self.superview && [keyPath isEqualToString:@"frame"]) {
        [self resizeItems];
        [self moveIndicatorToSelectedIndexWithAnimated:NO];
    }
}

#pragma mark Override Methods

- (void)insertSegmentWithImage:(UIImage *)image
                       atIndex:(NSUInteger)segment
                      animated:(BOOL)animated {
    [super insertSegmentWithImage:image atIndex:segment animated:animated];
    [self resizeItems];
    [self updateSegmentsList];
    [self addRippleLayers];
    [self performSelector:@selector(moveIndicatorToSelectedIndexWithAnimated:)
               withObject:[NSNumber numberWithBool:animated]
               afterDelay:.001f];
}

- (void)insertSegmentWithTitle:(NSString *)title
                       atIndex:(NSUInteger)segment
                      animated:(BOOL)animated {
    [super insertSegmentWithTitle:title atIndex:segment animated:animated];
    [self resizeItems];
    [self updateSegmentsList];
    [self addRippleLayers];
    [self performSelector:@selector(moveIndicatorToSelectedIndexWithAnimated:)
               withObject:[NSNumber numberWithBool:animated]
               afterDelay:.001f];
}

- (void)setTitle:(NSString *)title forSegmentAtIndex:(NSUInteger)segment {
    [super setTitle:title forSegmentAtIndex:segment];
    [self resizeItems];
    [self performSelector:@selector(moveIndicatorToSelectedIndexWithAnimated:)
               withObject:[NSNumber numberWithBool:YES]
               afterDelay:.001f];
}

- (void)setImage:(UIImage *)image forSegmentAtIndex:(NSUInteger)segment {
    [super setImage:image forSegmentAtIndex:segment];
    [self resizeItems];
    [self performSelector:@selector(moveIndicatorToSelectedIndexWithAnimated:)
               withObject:[NSNumber numberWithBool:YES]
               afterDelay:.001f];
}

- (void)removeSegmentAtIndex:(NSUInteger)segment animated:(BOOL)animated {
    [super removeSegmentAtIndex:segment animated:animated];
    [self updateSegmentsList];
    [self resizeItems];
    [self performSelector:@selector(moveIndicatorToSelectedIndexWithAnimated:)
               withObject:[NSNumber numberWithBool:animated]
               afterDelay:.001f];
}

#pragma mark Setter
- (void)setIndicatorColor:(UIColor *)color {
    _indicatorColor = color;
    indicatorView.backgroundColor = color;
}

- (void)setRippleColor:(UIColor *)rippleColor {
    _rippleColor = rippleColor;
    for (UIView *view in self.subviews) {
        for (CALayer *layer in view.layer.sublayers) {
            if ([layer isKindOfClass:[MDRippleLayer class]]) {
                [((MDRippleLayer *)layer)setEffectColor:_rippleColor
                                        withRippleAlpha:.1f
                                        backgroundAlpha:.1f];
                return;
            }
        }
    }
}

#pragma mark Public Methods

- (CGRect)getSelectedSegmentFrame {
    if (self.selectedSegmentIndex >= 0) {
        return ((UIView *)_tabs[self.selectedSegmentIndex]).frame;
    }
    return CGRectZero;
}

- (void)setTextFont:(UIFont *)textFont withColor:(UIColor *)textColor selectedFont:(UIFont*)selectedFont {
    font = textFont;
    [self setTitleTextAttributes:@{
                                   NSForegroundColorAttributeName :
                                       tabBar.colorTitleUnselectedBackground,
                                   NSFontAttributeName : textFont
                                   } forState:UIControlStateNormal];
    [self setTitleTextAttributes:@{
                                   NSForegroundColorAttributeName : tabBar.colorTitleSelecteBackground,
                                   NSFontAttributeName : selectedFont
                                   } forState:UIControlStateSelected];
}

- (void)moveIndicatorToFrame:(CGRect)frame withAnimated:(BOOL)animated {
    if (animated) {
        [UIView animateWithDuration:.2f
                         animations:^{
                             indicatorView.frame =
                             CGRectMake(frame.origin.x, self.bounds.size.height -
                                        indicatorView.frame.size.height,
                                        frame.size.width, indicatorView.frame.size.height);
                         }];
    } else {
        indicatorView.frame =
        CGRectMake(frame.origin.x, self.bounds.size.height - indicatorView.frame.size.height,
                   frame.size.width, indicatorView.frame.size.height);
    }
}

#pragma mark Private Methods
- (void)resizeItems {
    if (self.numberOfSegments <= 0)
        return;
    CGFloat maxItemSize = 0;
    CGFloat segmentedControlWidth = 0;
    if (!self.scrollEnabled) {
        maxItemSize = tabBar.bounds.size.width / self.numberOfSegments;
        segmentedControlWidth = 0;
        for (int i = 0; i < self.numberOfSegments; i++) {
            [self setWidth:maxItemSize forSegmentAtIndex:i];
            segmentedControlWidth += (maxItemSize);
        }
    }
    else{
        for (int i = 0; i < self.numberOfSegments; i++) {
            NSString *title = [self titleForSegmentAtIndex:i];
            CGSize itemSize = CGSizeZero;
            if (title) {
                itemSize = [title sizeWithAttributes:@{NSFontAttributeName : font}];
            } else {
                UIImage *image = [self imageForSegmentAtIndex:i];
                CGFloat height = self.bounds.size.height;
                CGFloat width = height / image.size.height * image.size.width;
                itemSize = CGSizeMake(width, height);
            }
            
            if (UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad)
                itemSize.width += kMDContentHorizontalPaddingIPad * 2;
            else
                itemSize.width += kMDContentHorizontalPaddingIPhone * 2;
            
            [self setWidth:itemSize.width forSegmentAtIndex:i];
            
            segmentedControlWidth += (itemSize.width);
            
            maxItemSize = MAX(maxItemSize, itemSize.width);
        }
        
        CGFloat holderWidth =
        tabBar.bounds.size.width - kMDTabBarHorizontalInset * 2;
        if (segmentedControlWidth < holderWidth) {
            if (self.numberOfSegments * maxItemSize < holderWidth) {
                maxItemSize = holderWidth / self.numberOfSegments;
            }
            
            segmentedControlWidth = 0;
            for (int i = 0; i < self.numberOfSegments; i++) {
                [self setWidth:maxItemSize forSegmentAtIndex:i];
                segmentedControlWidth += (maxItemSize);
            }
        }
    }
    self.frame = CGRectMake(0, 0, segmentedControlWidth, tabBar.tabBarHeight);
    
}

- (NSArray *)getSegmentList {
    // WARNING: This function gets frame from UISegment objects, undocumented
    // subviews of UISegmentedControl.
    // May break in iOS updates.
    
    NSMutableArray *segments =
    [NSMutableArray arrayWithCapacity:self.numberOfSegments];
    for (UIView *view in self.subviews) {
        if ([NSStringFromClass([view class]) isEqualToString:@"UISegment"]) {
            [segments addObject:view];
        }
    }
    
    NSArray *sortedSegments = [segments
                               sortedArrayUsingComparator:^NSComparisonResult (UIView *a, UIView *b) {
                                   if (a.frame.origin.x < b.frame.origin.x) {
                                       return NSOrderedAscending;
                                   } else if (a.frame.origin.x > b.frame.origin.x) {
                                       return NSOrderedDescending;
                                   }
                                   return NSOrderedSame;
                               }];
    
    return sortedSegments;
}

- (void)moveIndicatorToSelectedIndexWithAnimated:(BOOL)animated {
    if (self.selectedSegmentIndex < 0 && self.numberOfSegments > 0) {
        self.selectedSegmentIndex = 0;
    }
    NSInteger index = self.selectedSegmentIndex;
    
    CGRect frame = CGRectZero;
    
    if (index >= 0) {
        if ((index >= self.numberOfSegments) || (index >= _tabs.count)) {
            return;
        }
        frame = ((UIView *)_tabs[index]).frame;
    }
    // QUYTM ADD
    if (tabBar.highlightMode) {
        for (int i = 0; i < self.subviews.count; i ++) {
            if ([[self.subviews objectAtIndex:i] respondsToSelector:@selector(isSelected)] && [[self.subviews objectAtIndex:i]isSelected])
            {
                [[self.subviews objectAtIndex:i] setTintColor:self.highlightColor];
            }
            if ([[self.subviews objectAtIndex:i] respondsToSelector:@selector(isSelected)] && ![[self.subviews objectAtIndex:i] isSelected])
            {
                [[self.subviews objectAtIndex:i] setTintColor:[UIColor lightGrayColor]];
            }
        }
    }
    [self moveIndicatorToFrame:frame withAnimated:animated];
}

- (void)addRippleLayers {
    for (UIView *view in _tabs) {
        if (view.tag != NSIntegerMax) {
            BOOL hasRipple = NO;
            for (CALayer *layer in view.layer.sublayers) {
                if ([layer isKindOfClass:[MDRippleLayer class]]) {
                    hasRipple = YES;
                    break;
                }
            }
            
            if (!hasRipple) {
                MDRippleLayer *layer = [[MDRippleLayer alloc] initWithSuperView:view];
                [layer setEffectColor:_rippleColor
                      withRippleAlpha:.1f
                      backgroundAlpha:.1f];
                layer.enableElevation = NO;
                layer.rippleScaleRatio = 1;
            }
        }
    }
}

- (void)updateSegmentsList {
    _tabs = [self getSegmentList].mutableCopy;
}

#pragma mark Touch event
- (void)touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event {
    [super touchesBegan:touches withEvent:event];
    if (beingTouchedView)
        return;
    CGPoint point = [touches.allObjects[0] locationInView:self];
    for (UIView *view in self.subviews) {
        if (view.tag != NSIntegerMax && CGRectContainsPoint(view.frame, point)) {
            beingTouchedView = view;
            for (CALayer *layer in view.layer.sublayers) {
                if ([layer isKindOfClass:[MDRippleLayer class]]) {
                    [((MDRippleLayer *)layer)
                     startEffectsAtLocation:[view convertPoint:point fromView:self]];
                    return;
                }
            }
        }
    }
}

- (void)touchesCancelled:(NSSet *)touches withEvent:(UIEvent *)event {
    [super touchesCancelled:touches withEvent:event];
    if (beingTouchedView) {
        for (CALayer *layer in beingTouchedView.layer.sublayers) {
            if ([layer isKindOfClass:[MDRippleLayer class]]) {
                [((MDRippleLayer *)layer)stopEffects];
            }
        }
        
        beingTouchedView = nil;
    }
}

- (void)touchesEnded:(NSSet *)touches withEvent:(UIEvent *)event {
    [super touchesEnded:touches withEvent:event];
    if (beingTouchedView) {
        for (CALayer *layer in beingTouchedView.layer.sublayers) {
            if ([layer isKindOfClass:[MDRippleLayer class]]) {
                [((MDRippleLayer *)layer)stopEffects];
            }
        }
        
        beingTouchedView = nil;
    }
}

- (void)dealloc {
    [self removeObserver:self forKeyPath:@"bounds"];
}

@end

#pragma mark MDTabBar
@implementation MDTabBar {
    //MDSegmentedControl *segmentedControl;
    UIScrollView *scrollView;
}

- (instancetype)init {
    if (self = [super init]) {
        //    [self initContent];
    }
    return self;
}

- (instancetype)initWithCoder:(NSCoder *)aDecoder {
    if (self = [super initWithCoder:aDecoder]) {
        [self initContent];
    }
    return self;
}

- (instancetype)initWithFrame:(CGRect)frame {
    if (self = [super initWithFrame:frame]) {
        [self initContent];
    }
    return self;
}

- (instancetype)initWithItems:(NSArray *)items delegate:(id)delegate {
    if (self = [super init]) {
        [self initContent];
        _delegate = delegate;
        [self setItems:items];
    }
    
    return self;
}

- (void)layoutSubviews {
    [super layoutSubviews];
    
    [_segmentedControl resizeItems];
    
    scrollView.frame = CGRectMake(0, 0, self.bounds.size.width + 5, self.bounds.size.height);
    [scrollView setContentInset:UIEdgeInsetsMake(0, kMDTabBarHorizontalInset, 0,
                                                 kMDTabBarHorizontalInset)];
    [scrollView setContentSize:_segmentedControl.bounds.size];
}

#pragma mark Private methods
- (void)initContent {
    self.indicatorHeight = 1;
    self.colorTitleSelecteBackground = [UIColor whiteColor];
    self.colorTitleUnselectedBackground = [[UIColor whiteColor] colorWithAlphaComponent:DISABLED_TEXT_ALPHA];
    self.identifier = @"DEFAULT";
    self.tag = MDTabBarTagTypeDefault;
    _segmentedControl = [[MDSegmentedControl alloc] initWithTabBar:self indicatorHeight:self.indicatorHeight];
    [_segmentedControl setTintColor:[UIColor clearColor]];
    
    scrollView = [[UIScrollView alloc] init];
    [scrollView setShowsHorizontalScrollIndicator:NO];
    [scrollView setShowsVerticalScrollIndicator:NO];
    // scrollView.bounces = NO;
    
    scrollView.clipsToBounds = NO;
    
    [scrollView addSubview:_segmentedControl];
    
    [self addSubview:scrollView];
    
    [self setBackgroundColor:[UIColor clearColor]];
//    self.layer.shadowColor = [UIColor blackColor].CGColor;
//    self.layer.shadowRadius = 1;
//    self.layer.shadowOpacity = .5;
//    self.layer.shadowOffset = CGSizeMake(0, 1.5);
    
    [self setTextColor:self.colorTitleUnselectedBackground];
    //  [self setTextFont:[UIFontHelper robotoFontWithName:@"roboto-medium" size:14]];
    [self setTextFont:[FontUtils aileronRegularWithSize:17.0]];
    [self setIndicatorColor:[UIColor whiteColor]];
    [self setRippleColor:[UIColor whiteColor]];
}

- (void)willMoveToSuperview:(UIView *)newSuperview {
    [super willMoveToSuperview:newSuperview];
    if (newSuperview) {
        [_segmentedControl addObserver:self
                            forKeyPath:@"frame"
                               options:0
                               context:nil];
    }
}

- (void)removeFromSuperview {
    [_segmentedControl removeObserver:self forKeyPath:@"frame"];
    [super removeFromSuperview];
}

- (void)observeValueForKeyPath:(NSString *)keyPath
                      ofObject:(id)object
                        change:(NSDictionary *)change
                       context:(void *)context {
    if (object == _segmentedControl && [keyPath isEqualToString:@"frame"]) {
        [scrollView setContentSize:_segmentedControl.bounds.size];
    }
}

- (void)updateItemAppearance{
    if (_textColor && _textFont) {
        [_segmentedControl setTextFont:_textFont withColor:_textColor selectedFont:_selectedFont];
    }
}

- (void)scrollToSelectedIndex {
    CGRect frame = [_segmentedControl getSelectedSegmentFrame];
    CGFloat contentOffset = frame.origin.x + kMDTabBarHorizontalInset -
    (self.frame.size.width - frame.size.width) / 2;
    if (contentOffset > scrollView.contentSize.width + kMDTabBarHorizontalInset -
        self.frame.size.width) {
        contentOffset = scrollView.contentSize.width + kMDTabBarHorizontalInset -
        self.frame.size.width;
    } else if (contentOffset < -kMDTabBarHorizontalInset) {
        contentOffset = -kMDTabBarHorizontalInset;
    }
    
    [scrollView setContentOffset:CGPointMake(contentOffset, 0) animated:YES];
}

#pragma mark Public methods

- (void)updateSelectedIndex:(NSInteger)selectedIndex {
    _selectedIndex = selectedIndex;
    [self scrollToSelectedIndex];
    if (_delegate) {
        [_delegate tabBar:self didChangeSelectedIndex:_selectedIndex];
    }
}

- (void)setItems:(NSArray *)items {
    [_segmentedControl removeAllSegments];
    NSUInteger index = 0;
    for (id item in items) {
        [self insertItem:item atIndex:index animated:NO];
        index++;
    }
    
    self.selectedIndex = 0;
}

- (void)insertItem:(id)item atIndex:(NSUInteger)index animated:(BOOL)animated {
    if ([item isKindOfClass:[NSString class]]) {
        [_segmentedControl insertSegmentWithTitle:item
                                          atIndex:index
                                         animated:animated];
    } else if ([item isKindOfClass:[UIImage class]]) {
        [_segmentedControl insertSegmentWithImage:item
                                          atIndex:index
                                         animated:animated];
    }
}

- (void)removeItemAtIndex:(NSUInteger)index animated:(BOOL)animated {
    [_segmentedControl removeSegmentAtIndex:index animated:animated];
}

- (void)replaceItem:(id)item atIndex:(NSUInteger)index {
    if ([item isKindOfClass:[NSString class]]) {
        [_segmentedControl setTitle:item forSegmentAtIndex:index];
        
    } else if ([item isKindOfClass:[UIImage class]]) {
        [_segmentedControl setImage:item forSegmentAtIndex:index];
    }
}

- (void)moveIndicatorToFrame:(CGRect)frame withAnimated:(BOOL)animated {
    [_segmentedControl moveIndicatorToFrame:frame withAnimated:animated];
}

#pragma mark Setters

- (void)setBackgroundColor:(UIColor *)backgroundColor {
    _backgroundColor = backgroundColor;
    [scrollView setBackgroundColor:backgroundColor];
}

- (void)setTextColor:(UIColor *)textColor {
    _textColor = textColor;
    [self updateItemAppearance];
}

- (void)setColorTitleSelecteBackground:(UIColor *)colorTitleSelecteBackground {
    _colorTitleSelecteBackground = colorTitleSelecteBackground;
    [self updateItemAppearance];
}


- (void)setIdentifier:(NSString *)identifier{
    _identifier = identifier;
}

- (void)setColorTitleUnselectedBackground:(UIColor *)colorTitleUnselectedBackground {
    _colorTitleUnselectedBackground = colorTitleUnselectedBackground;
    [self updateItemAppearance];
}

- (void)setHighlightColor:(UIColor *)highlightColor {
    _highlightColor = highlightColor;
    [_segmentedControl setHighlightColor:highlightColor];
}

- (void) setHighlightMode:(BOOL)highlightMode {
    _highlightMode = highlightMode;
}

- (void)setIndicatorColor:(UIColor *)indicatorColor {
    _indicatorColor = indicatorColor;
    [_segmentedControl setIndicatorColor:_indicatorColor];
}

- (void)setRippleColor:(UIColor *)rippleColor {
    _rippleColor = rippleColor;
    [_segmentedControl setRippleColor:_rippleColor];
}

- (void)setTextFont:(UIFont *)textFont {
    _textFont = textFont;
    _selectedFont = textFont;
    [self updateItemAppearance];
}

- (void)setSelectedFont:(UIFont *)selectedFont {
    _selectedFont = selectedFont;
    [self updateItemAppearance];
}

- (void)setIndicatorHeight:(float)indicatorHeight{
    _indicatorHeight = indicatorHeight;
    [_segmentedControl updateIndicatorHeight:indicatorHeight];
}

- (void)setSelectedIndex:(NSUInteger)selectedIndex {
    if (selectedIndex < _segmentedControl.numberOfSegments) {
        _selectedIndex = selectedIndex;
        if (_segmentedControl.selectedSegmentIndex != _selectedIndex) {
            [_segmentedControl setSelectedSegmentIndex:_selectedIndex];
            [self scrollToSelectedIndex];
        }
    }
}

- (NSInteger)numberOfItems {
    return _segmentedControl.numberOfSegments;
}

- (NSMutableArray *)tabs {
    return _segmentedControl.tabs;
}

@end
