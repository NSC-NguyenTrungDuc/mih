//
//  PHRTimeSlider.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/5/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@class PHRTimeSlider;
@protocol PHRTimeSliderDelegate <NSObject>
- (void) scrollViewTimeDidScroll:(int) hour andMinute:(int) minute;
@end

@interface PHRTimeSlider : UIView <UIScrollViewDelegate>

@property (strong, nonatomic) UIScrollView *scrollViewHour;
@property (strong, nonatomic) UIScrollView *scrollViewMinute;

@property (nonatomic, weak) id<PHRTimeSliderDelegate> delegate;

- (void)initialize:(id)delegate;

@end
