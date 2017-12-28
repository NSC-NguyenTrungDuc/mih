//
//  CustomSlider.m
//  PHR
//
//  Created by DEV-MinhNN on 10/3/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "CustomSlider.h"

@implementation CustomSlider

- (void)awakeFromNib {
    [super awakeFromNib];
    [self defaultsInitialize];
}

- (void)defaultsInitialize {
    self.continuous = YES;
    
    UIImage *thumbImage = [UIImage imageNamed:@"Slide_bar"];
    [self setThumbImage:thumbImage forState:UIControlStateNormal];
    [self setCenter:CGPointMake(0.5, 0.5)];
    
    [self setMinimumTrackTintColor:RGBCOLOR(255.0, 128.0, 52.0)];
    [self setMaximumTrackTintColor:RGBCOLOR(206.0, 206.0, 206.0)];
}

- (void)addIamgeValueSteepOnSlider:(int)maxValue {
    int steepValue = (SCREEN_WIDTH - 20.0) / (maxValue - 1);
    
    for (int i = 0; i < maxValue; i++) {
        UILabel *lbText = [[UILabel alloc] init];
        lbText.text = [NSString stringWithFormat:@"%d", (i + 1)];
        [lbText setFont:[FontUtils aileronRegularWithSize:11.0]];
        [lbText setTextColor:PHR_COLOR_GRAY];
        
        UIImageView *imgValue = [[UIImageView alloc] init];
        if (i == 0) {
            [lbText setFrame:CGRectMake(1.0, 16.0, 10.0, 15.0)];
            [imgValue setFrame:CGRectMake(2.0, 0.0, 1.0, 15.0)];
        }
        
        if (i > 0 && i < 5) {
            [lbText setFrame:CGRectMake(steepValue * i + 1.0 , 16.0, 12.0, 15.0)];
            [imgValue setFrame:CGRectMake(steepValue * i + 2.0 + 0.75 * (i - 1), 0.0, 1.0, 15.0)];
        }
        
        if (i > 4) {
            [lbText setFrame:CGRectMake(steepValue * i + 3.0 , 16.0, 12.0, 15.0)];
            [imgValue setFrame:CGRectMake(steepValue * i + 2.0 + 0.75 * (i - 1), 0.0, 1.0, 15.0)];
        }
        
        imgValue.image = [UIImage imageNamed:@"Slide_Bar_Div"];
        [self addSubview:lbText];
        [self addSubview:imgValue];
    }
}

@end
