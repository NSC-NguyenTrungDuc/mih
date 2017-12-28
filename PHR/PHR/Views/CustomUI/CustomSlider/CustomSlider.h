//
//  CustomSlider.h
//  PHR
//
//  Created by DEV-MinhNN on 10/3/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface CustomSlider : UISlider

@property (nonatomic) CGFloat markWidth;
@property (nonatomic) NSArray *markPositions;
@property (nonatomic) int steepValue;

- (void)addIamgeValueSteepOnSlider:(int)maxValue;

@end
