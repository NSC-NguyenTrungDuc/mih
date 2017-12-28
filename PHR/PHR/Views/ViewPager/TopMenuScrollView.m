//
//  TopMenuScrollView.m
//  TopMenuScrollView
//
//  Created by 박광범 on 2015. 7. 15..
//  Copyright (c) 2015년 Yellomobile. All rights reserved.
//

#import "TopMenuScrollView.h"
#import "TriangleView.h"
#import "FontUtils.h"

#define kIntroMarginW 0
#define kViewCenterX self.center.x
#define kDefaultEdgeInsets UIEdgeInsetsMake(6, 12, 6, 12)

@interface TopMenuScrollView (){
    NSMutableArray *arr_Button;
    UIFont *font;
}

@end

@implementation TopMenuScrollView

-(void)awakeFromNib{
    [super awakeFromNib];
    
    [self settingScroll];
}

- (id)initWithFrame:(CGRect)frame delegate:(id<TopMenuDelegate>)delegate{
    self = [super init];
    if ((self = [super initWithFrame:frame]))
    {
        self.delegate = self;
        self.topMenuDelegate = delegate;
        
        [self settingScroll];
    }
    
    return self;
}

-(void)settingScroll {
    self.scrollEnabled = YES;
    self.scrollsToTop = NO;
    self.showsVerticalScrollIndicator = NO;
    self.showsHorizontalScrollIndicator = NO;
    self.pagingEnabled = NO;
    self.bounces = YES;
    self.clipsToBounds = YES;
    self.layer.masksToBounds = YES;
    font = [FontUtils aileronSemiBoldWithSize:18];
    if(arr_Button == nil)
        arr_Button = [[NSMutableArray alloc]init];
}

+ (CGFloat)widthForMenuTitle:(NSString *)title buttonEdgeInsets:(UIEdgeInsets)buttonEdgeInsets
{
    UIFont *font = [FontUtils aileronSemiBoldWithSize:18];
    CGSize size = [title sizeWithAttributes:@{NSFontAttributeName:font}];
    return CGSizeMake(size.width + buttonEdgeInsets.left + buttonEdgeInsets.right, size.height + buttonEdgeInsets.top + buttonEdgeInsets.bottom).width;
}

- (void)calcurateWidth:(NSArray *)menuList
{
    [self calcurateWidth:menuList buttonEdgeInsets:kDefaultEdgeInsets];
}

-(void)calcurateWidth:(NSArray *)menuList buttonEdgeInsets:(UIEdgeInsets)buttonEdgeInsets{
    [self clearView];
   
    __block CGFloat buttonHeight = self.frame.size.height;
    __block CGFloat cWidth = 0;
    
    [menuList enumerateObjectsUsingBlock:^(NSDictionary *menu, NSUInteger idx, BOOL *stop) {
         BOOL isLastObject = idx == [menuList count]-1;
        BOOL isFirstObject = idx == 0;
       
        NSString *tagTitle = menu[PHR_TYPE_IDENTIFIER];
        
        CGFloat buttonWidth = [TopMenuScrollView widthForMenuTitle:tagTitle buttonEdgeInsets:buttonEdgeInsets];
        if (isFirstObject) {
            cWidth = [UIScreen mainScreen].bounds.size.width / 2 - buttonWidth / 2 ;
        }
        UIButton *button = [UIButton buttonWithType:UIButtonTypeCustom];
        button.frame = CGRectMake(cWidth, 0.0f, buttonWidth, buttonHeight);
        [button setTitle:tagTitle forState:UIControlStateNormal];
        button.titleLabel.font = font;
//        [button setBackgroundImage:[TopMenuScrollView imageWithColor:[UIColor blackColor] RectMake:buttonFrame].centerStretchableImage forState:UIControlStateNormal];
        //[button setBackgroundImage:[UIImage imageNamed:@"underline.png"] forState:UIControlStateSelected];
        [button setTitleColor:[[UIColor whiteColor] colorWithAlphaComponent:0.6] forState:UIControlStateNormal];
        [button setTitleColor:[UIColor whiteColor] forState:UIControlStateSelected];
        [button addTarget:self action:@selector(buttonPressed:) forControlEvents:UIControlEventTouchUpInside];
        button.tag = idx;
        button.selected = (idx == 0);
        [self addSubview:button];
        
        [arr_Button addObject:button];
        
        cWidth += buttonWidth + kIntroMarginW;
        if (isLastObject){
            cWidth += [UIScreen mainScreen].bounds.size.width / 2;
        }
    }];
//    self.clipsToBounds = YES;
//    self.layer.masksToBounds = NO;
//    
//    float triangleWidth = 10;
//    float triangleHeight = 10;
//    TriangleView *triangleView = [[TriangleView alloc] initWithFrame:CGRectMake(self.frame.size.width / 2 - triangleWidth / 2 , 0, triangleWidth, triangleHeight)];
//    [triangleView setBackgroundColor:[UIColor clearColor]];
//     triangleView.arrayRGB = [NSArray arrayWithObjects:@"205",@"102", @"0", nil];
//    [self addSubview:triangleView];
    
    self.contentSize = CGSizeMake(cWidth, self.frame.size.height);
}

- (void)clearView
{
    [self.subviews enumerateObjectsUsingBlock:^(UIView *v, NSUInteger idx, BOOL *stop) {
        [v removeFromSuperview];
    }];
}

- (int)numberOfPages {
    return (int)arr_Button.count;
}

#pragma mark - Events

- (void)buttonPressed:(id)sender{
    UIButton *btn = (UIButton *)sender;
    
    [arr_Button enumerateObjectsUsingBlock:^(UIButton *obj, NSUInteger idx, BOOL *stop) {
        // Button Selected
        obj.selected = (btn.tag == idx);
    }];
    
    CGFloat btnX = btn.frame.origin.x;
    CGFloat btnCenterX = btn.center.x;
    CGPoint scrollPoint;
    
    /* Setting Scroll Center Point */
    if(btnCenterX > kViewCenterX && self.contentSize.width + kViewCenterX - self.frame.size.width > btnCenterX){
        scrollPoint = CGPointMake(btnX - kViewCenterX + (btn.frame.size.width/2), 0.0f);
    }else if(self.contentSize.width + kViewCenterX - self.frame.size.width < btnCenterX){
        scrollPoint = CGPointMake(self.contentSize.width - self.bounds.size.width,0.0f);
    }else {
        scrollPoint = CGPointMake(0.0f,0.0f);
    }
    [self setContentOffset:scrollPoint animated:YES];
    
    /* Call Delegate */
    if(self.topMenuDelegate && [self.topMenuDelegate respondsToSelector:@selector(selectTopMenu:)]){
        [self.topMenuDelegate selectTopMenu:btn.tag];
    }
}

#pragma mark - Page Change
-(void)setScrollPage:(NSInteger)page{
    [self buttonPressed:arr_Button[page]];
}

- (void)setTextFont:(UIFont*)textFont {
    font = textFont;
}

@end
