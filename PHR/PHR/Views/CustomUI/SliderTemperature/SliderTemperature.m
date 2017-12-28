//
//  SliderTemperature.m
//  PHR
//
//  Created by DEV-MinhNN on 10/14/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "SliderTemperature.h"

@implementation SliderTemperature

- (void)drawRect:(CGRect)rect {
    UIImage *thumbImage = [UIImage imageNamed:@"Slide_bar"];
    [self setThumbImage:thumbImage forState:UIControlStateNormal];
    [self setCenter:CGPointMake(0.5, 0.5)];
    
    UIImage *sliderTrackImage = [[UIImage imageNamed:@"Temperature_Status_Bar"] resizableImageWithCapInsets:UIEdgeInsetsMake(0, 7, 0, 0)];
    
    [self setMinimumTrackImage: sliderTrackImage forState: UIControlStateNormal];    
    [self setMaximumTrackTintColor:[UIColor clearColor]];
}

- (CGRect)trackRectForBounds:(CGRect)bounds{
    CGRect customBounds = CGRectMake(bounds.origin.x, bounds.origin.y + 8.0, bounds.size.width, 8.0);
    return customBounds;
}

@end
