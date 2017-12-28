//
//  DALinedTextView.m
//  DALinedTextView
//
//  Created by Daniel Amitay on 5/12/13.
//  Copyright (c) 2013 Daniel Amitay. All rights reserved.
//

#import "DALinedTextView.h"

#define SYSTEM_VERSION_GREATER_THAN_OR_EQUAL_TO(v)  ([[[UIDevice currentDevice] systemVersion] compare:v options:NSNumericSearch] != NSOrderedAscending)
#define DEFAULT_HORIZONTAL_COLOR                    [UIColor colorWithRed:255.0/255.0 green:221.0/255.0 blue:167.0/255.0 alpha:1.0f]
#define DEFAULT_VERTICAL_COLOR                      [UIColor colorWithRed:231.0/255.0 green:183.0/255.0 blue:219.0/255.0 alpha:1.0f]
#define DEFAULT_MARGINS                             UIEdgeInsetsMake(10.0f, 20.0f, 0.0f, 20.0f)

@interface DALinedTextView () <UITextViewDelegate, NSLayoutManagerDelegate>

@property (nonatomic, assign) UIView *webDocumentView;

@end

@implementation DALinedTextView

+ (void)initialize
{
    if (self == [DALinedTextView class]) {
        id appearance = [self appearance];
        [appearance setContentMode:UIViewContentModeRedraw];
        [appearance setHorizontalLineColor:DEFAULT_HORIZONTAL_COLOR];
        [appearance setVerticalLineColor:DEFAULT_VERTICAL_COLOR];
        [appearance setMargins:DEFAULT_MARGINS];
    }
}


#pragma mark - Superclass overrides

- (void)awakeFromNib {
    [self setStyleToNoteView];
}

- (id)initWithFrame:(CGRect)frame
{
    self = [super initWithFrame:frame];
    if (self) {
        // Recycling the font is necessary
        // For proper line/text alignment
        UIFont *font = self.font;
        self.font = nil;
        self.font = font;
        
        // We need to grab the underlying webView
        // And resize it along with the margins
        NSString *desiredDocumentClass = (SYSTEM_VERSION_GREATER_THAN_OR_EQUAL_TO(@"7.0")
                                          ? @"UITextContainerView"
                                          : @"UIWebDocumentView");
        for (UIView *subview in self.subviews) {
            if ([NSStringFromClass([subview class]) isEqualToString:desiredDocumentClass]) {
                self.webDocumentView = subview;
            }
        }
        self.margins = [self.class.appearance margins];
    }
    return self;
}

- (void)drawRect:(CGRect)rect
{
    UIScreen *screen = self.window.screen ?: [UIScreen mainScreen];
    CGFloat lineWidth = 1.0f / screen.scale;
    CGContextRef context = UIGraphicsGetCurrentContext();
    CGContextSetLineWidth(context, lineWidth);
    CGFloat lineSpacing = 1.5f;

    if (self.horizontalLineColor) {
        CGContextBeginPath(context);
        CGContextSetStrokeColorWithColor(context, self.horizontalLineColor.CGColor);
        
        CGFloat baseOffset = 5.0 + self.font.descender;
        CGFloat screenScale = [UIScreen mainScreen].scale;
        CGFloat boundsX = self.bounds.origin.x;
        CGFloat boundsWidth = self.bounds.size.width;
        
        NSInteger firstVisibleLine = MAX(1, (self.contentOffset.y / (self.font.lineHeight * lineSpacing)));
        NSInteger lastVisibleLine = ceilf((self.contentOffset.y + self.bounds.size.height) / (self.font.lineHeight * lineSpacing));
        for (NSInteger line = firstVisibleLine; line <= lastVisibleLine; ++line)
        {
            CGFloat linePointY = (baseOffset + (self.font.lineHeight * line * lineSpacing));
            CGFloat roundedLinePointY = roundf(linePointY * screenScale) / screenScale;
            
            CGContextMoveToPoint(context, boundsX, roundedLinePointY);
            CGContextAddLineToPoint(context, boundsWidth, roundedLinePointY);
        }
        CGContextClosePath(context);
        CGContextStrokePath(context);
    }
    
    if (self.verticalLineColor) {
        CGContextBeginPath(context);
        CGContextSetStrokeColorWithColor(context, self.verticalLineColor.CGColor);
        CGContextMoveToPoint(context, 22.0f, self.contentOffset.y);
        CGContextAddLineToPoint(context, 22.0f, self.contentOffset.y + self.bounds.size.height);
        CGContextClosePath(context);
        CGContextStrokePath(context);
        
        CGContextBeginPath(context);
        CGContextSetStrokeColorWithColor(context, self.verticalLineColor.CGColor);
        CGContextMoveToPoint(context, 24.0f, self.contentOffset.y);
        CGContextAddLineToPoint(context, 24.0f, self.contentOffset.y + self.bounds.size.height);
        CGContextClosePath(context);
        CGContextStrokePath(context);
    }
}


- (void)setStyleToNoteView {
    
    self.showsHorizontalScrollIndicator = NO;
    self.showsVerticalScrollIndicator = NO;
    
    [self setAutocorrectionType:UITextAutocorrectionTypeNo];
    
    UIImage *patternImage = [UIImage imageNamed:@"BGNote"];
    UIColor* color = [UIColor colorWithPatternImage:patternImage];
    self.backgroundColor = color;

    [self.layer setBorderWidth:0.5];
    [self.layer setBorderColor:RGBCOLOR(170.0, 170.0, 170.0).CGColor];
    
//    [self setFont:[FontUtils aileronRegularWithSize:17.0]];
//    [self setTextColor:PHR_COLOR_GRAY];
    
    NSMutableParagraphStyle *paragraphStyle = [[NSMutableParagraphStyle alloc] init];
    paragraphStyle.headIndent = 0;
    paragraphStyle.firstLineHeadIndent = 0;
    paragraphStyle.lineSpacing = 7;
    NSDictionary *attrsDictionary = @{ NSParagraphStyleAttributeName: paragraphStyle };
    
    self.attributedText = [[NSAttributedString alloc] initWithString:@"" attributes:attrsDictionary];
}

- (void)setFont:(UIFont *)font {
    [super setFont:font];
    [self setNeedsDisplay];
}

- (void)setTextContainerInset:(UIEdgeInsets)textContainerInset {
    [super setTextContainerInset:textContainerInset];
    [self setNeedsDisplay];
}

#pragma mark - Property methods

- (void)setHorizontalLineColor:(UIColor *)horizontalLineColor
{
    _horizontalLineColor = horizontalLineColor;
    [self setNeedsDisplay];
}

- (void)setVerticalLineColor:(UIColor *)verticalLineColor
{
    _verticalLineColor = verticalLineColor;
    [self setNeedsDisplay];
}

- (void)setMargins:(UIEdgeInsets)margins {
    
    self.textContainerInset = (UIEdgeInsets) {
        .top = 10.0,
        .left = 25.0,
        .bottom = 0.0,
        .right = self.margins.right + self.margins.left
    };
    [self setContentSize:self.contentSize];
}

@end
