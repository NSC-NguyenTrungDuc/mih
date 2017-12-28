//
//  BaseViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 9/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PHRBaseViewController.h"
#import "RatingSleepDialog.h"
#import "PHREnums.h"

@interface BaseViewController : PHRBaseViewController{
    
}
@property (nonatomic, assign) PHRGroupType type;

- (void)enableSlideMenu:(BOOL)isEnable;
- (void)setImageToBackgroundStandard:(UIImageView *)imageBackground;
- (void)setImageToBackgroundBaby:(UIImageView *)imageBackground;
- (void)setImageToBackground:(UIImageView *)imageBackground;
- (void)setImageToBackgroundStandardWithBlur:(UIImageView *)imageBackground;
- (void)setImageToBackgroundBabyWithBlur:(UIImageView *)imageBackground;
@property (strong, nonatomic) RatingSleepDialog *ratingScreen;
@end
