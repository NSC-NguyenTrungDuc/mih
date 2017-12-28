//
//  PHRSlider.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/13/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "IQActionSheetPickerView.h"

@class PHRSlider;
@protocol PHRSliderDelegate <NSObject>
- (void) scrollViewScroll:(PHRSlider*)slider value:(double) valueScroll;
- (void) dateTimeChanged: (NSDate*) date;
@end

@interface PHRSlider : UIView <UIScrollViewDelegate , IQActionSheetPickerViewDelegate>

@property (strong, nonatomic) UIView *viewHeader;
@property (strong, nonatomic) UIView *viewMain;
@property (strong, nonatomic) UIScrollView *scrollView;
@property (strong, nonatomic) UIView *viewMiddleDashedLine;
@property (nonatomic, weak) id<PHRSliderDelegate> delegate;
@property (strong, nonatomic) UILabel *labelValue;
@property (strong, nonatomic) UIButton *buttonDateTime;
@property (strong, nonatomic) NSDate *datetime;

- (void)initialize:(id)delegate andAddTypeName:(NSString*) typeName;
- (void)scrollToPosition:(float)value;
- (void)updateTime:(NSDate *)date;
- (void)resetView:(NSString*)typeName;


@end


