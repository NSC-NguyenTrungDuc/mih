//
//  DateTimeView.h
//  PHR
//
//  Created by SonNV1368 on 10/7/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef void(^PHRDateTimeViewEvent)();

@interface PHRDateTimeView : UIView{
    
}
@property (nonatomic, copy) void (^actionSelectDate)(void);
@property (nonatomic, copy) void (^actionOpenDatePicker)(void);
@property (strong, nonatomic) NSDate *datetime;
@property (strong, nonatomic) UILabel *labelTitleContent;
@property (strong, nonatomic) NSString *titleContent;

- (void)setClickEnable:(BOOL)enable;
- (NSString*)stringDateParam;

- (void)updateTime:(NSDate *)date;
- (void)updateTime:(NSDate *)date shortFormat:(BOOL)shortFormat;
- (void)updateTimeFromString:(NSString *)strTime;
/*
 Datetime string to show on UI
 */
- (NSString*)stringDateWithShortFormat:(BOOL)shortFormat;
@end
