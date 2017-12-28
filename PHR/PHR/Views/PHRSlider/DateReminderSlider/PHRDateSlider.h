//
//  PHRDateSlider.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/4/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@class PHRDateSlider;
@protocol PHRDateSliderDelegate <NSObject>
- (void) scrollViewDateDidScroll:(int) date;
@end

@interface PHRDateSlider : UIView <UIScrollViewDelegate>

@property (strong, nonatomic) UIScrollView *scrollView;
@property (nonatomic, weak) id<PHRDateSliderDelegate> delegate;


- (void)initialize:(id)delegate;

@end
