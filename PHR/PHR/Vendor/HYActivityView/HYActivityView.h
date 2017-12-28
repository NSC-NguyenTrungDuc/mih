//
//  HYActivityView.h
//  Test
//
//  Created by crte on 13-11-6.
//  Copyright (c) 2013年 crte. All rights reserved.
//

#import <UIKit/UIKit.h>

@class ButtonView;
@class HYActivityView;

typedef void(^ButtonViewHandler)(ButtonView *buttonView);

@interface ButtonView : UIView

@property (nonatomic, strong) UILabel *textLabel;

@property (nonatomic, strong) UIButton *imageButton;

@property (nonatomic, strong) UIImage *image;

@property (nonatomic, strong) UIImage *imageSelected;

@property (nonatomic, weak) HYActivityView *activityView;

@property (nonatomic) BOOL isSelected;

- (id)initWithType:(NSInteger)type text:(NSString *)text image:(UIImage *)image andImageSelected:(UIImage *)imageSelected handler:(ButtonViewHandler)handler;

- (void)setupToButtonInView;

- (void)setupToImageButtoninView;

@end

@interface HYActivityView : UIView

//背景颜色, 默认是透明度0.95的白色
@property (nonatomic, strong) UIColor *bgColor;

//标题
@property (nonatomic, strong) UILabel *titleLabel;

//取消按钮
@property (nonatomic, strong) UIButton *cancelButton;

//一行有多少个, 默认是4. iPhone竖屏不会多于4, 横屏不会多于6. ipad没试, 不建议ipad用这个.
@property (nonatomic, assign) int numberOfButtonPerLine;

//是否可以通过下滑手势关闭视图, 默认为YES
@property (nonatomic, assign) BOOL useGesturer;

//是否正在显示
@property (nonatomic, getter = isShowing) BOOL show;

- (id)initWithTitle:(NSString *)title referView:(UIView *)referView;

- (void)addButtonView:(ButtonView *)buttonView;

- (void)show;

- (void)hide;

- (void)saveButtonClicked:(UIButton *)button;

@end
