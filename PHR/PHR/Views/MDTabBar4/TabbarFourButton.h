//
//  TabbarFourButton.h
//  PHR
//
//  Created by NextopHN on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "MDTabBar.h"

@interface TabbarFourButton : MDTabBar

- (void) initContent4Button;
- (void) initContent4ButtonWhiteTransperent;
- (void)initContentWhiteTransperent:(NSArray*)array colorSelected:(UIColor*)selectedColor andUnselectedColor:(UIColor*)unselectedColor textFont:(UIFont*)font selectedFont:(UIFont*)selectedFont;
@end