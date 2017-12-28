//
//  TabbarFourButton.m
//  PHR
//
//  Created by NextopHN on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "TabbarFourButton.h"
#import "FontUtils.h"

@implementation TabbarFourButton

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/
- (void) initContent4Button{
    self.segmentedControl.scrollEnabled = NO;
    [self setItems:@[kLocalizedString(kDaily), kLocalizedString(kWeekly), kLocalizedString(kMonthly), kLocalizedString(kYear)]];
    self.highlightColor = [PHRUIColor colorBodyMeasurementTabbarHeaderBackground:1.0];
    self.indicatorColor = [PHRUIColor colorBodyMeasurementTabbarHeaderBackground:1.0];
    self.identifier = @"4";
    self.tag = MDTabBarTagTypeFourButton;
    self.backgroundColor = [PHRUIColor colorFromHex:@"#ffffff" alpha:1.0];
    self.colorTitleSelecteBackground = [PHRUIColor colorFromHex:@"#ffffff" alpha:1.0];
    self.colorTitleUnselectedBackground = [PHRUIColor colorFromHex:@"#6c6c6c" alpha:1.0];
    [self.segmentedControl setTintColor:[UIColor lightGrayColor]];
    [self setTextFont:[FontUtils aileronRegularWithSize:12.0]];

    [self setIndicatorHeight:0];
    [self setHighlightMode:YES];
}

- (void) initContent4ButtonWhiteTransperent{
    [self setItems:@[kLocalizedString(kDaily), kLocalizedString(kWeekly), kLocalizedString(kMonthly), kLocalizedString(kYear)]];
    //self.highlightColor = [PHRUIColor colorFromHex:@"#ffffff" alpha:0.6];
    self.indicatorColor = [PHRUIColor colorFromHex:@"#ffffff" alpha:0.6];
    self.identifier = @"4";
    self.tag = MDTabBarTagTypeFourButton;
    self.backgroundColor = [PHRUIColor colorFromHex:@"#ffffff" alpha:0.1];
    self.colorTitleSelecteBackground = [PHRUIColor colorFromHex:@"#ffffff" alpha:1.0];
    self.colorTitleUnselectedBackground = [PHRUIColor colorFromHex:@"#ffffff" alpha:0.6];
    [self.segmentedControl setTintColor:[UIColor clearColor]];
    [self setTextFont:[FontUtils aileronRegularWithSize:12.0]];
    [self setIndicatorHeight:self.bounds.size.height];
    [self setHighlightMode:NO];
}


- (void)initContentWhiteTransperent:(NSArray*)array colorSelected:(UIColor*)selectedColor andUnselectedColor:(UIColor*)unselectedColor textFont:(UIFont*)font selectedFont:(UIFont*)selectedFont{
    if (array) {
        [self setItems:array];
    } else {
        [self setItems:@[kLocalizedString(kByDay), kLocalizedString(kByWeek), kLocalizedString(kByMonth), kLocalizedString(kByYear)]];
    }
    //self.highlightColor = [UIColor clearColor];
    self.indicatorColor = [UIColor clearColor];
    self.identifier = @"4";
    self.tag = MDTabBarTagTypeFourButtonNoBorder;
    self.backgroundColor = [UIColor clearColor];
    self.rippleColor = [UIColor clearColor];
    self.colorTitleSelecteBackground = selectedColor;
    self.colorTitleUnselectedBackground = unselectedColor;
    [self.segmentedControl setTintColor:[UIColor clearColor]];
    [self setTextFont:font];
    [self setSelectedFont:selectedFont];
    [self setIndicatorHeight:self.bounds.size.height];
    [self setHighlightMode:NO];
}

@end
