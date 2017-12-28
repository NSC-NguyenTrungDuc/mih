//
//  RatingSleepDialog.h
//  PHR
//
//  Created by BillyMobile on 5/31/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "RatingBar.h"

@interface RatingSleepDialog : UIView<RatingDelegate>{
    NSString *_totalTimeSleep;
    NSDate *myCurrentDate;
}
@property (weak, nonatomic) IBOutlet UILabel *lblYouHadJustWoken;
@property (strong, nonatomic) RatingBar *ratingStar;
@property (weak, nonatomic) IBOutlet UILabel *lblHowWasYourSleep;
@property (weak, nonatomic) IBOutlet UIView *viewRatingBar;
@property (weak, nonatomic) IBOutlet UILabel *lblNumberStar;
@property (weak, nonatomic) IBOutlet UIView *viewContent;
@property (weak, nonatomic) IBOutlet UIButton *btnRatingSleep;
@property (strong, nonatomic) NSString *startSleepTime;

- (IBAction)actionRatingSleep:(id)sender;

- (IBAction)actionHidden:(id)sender ;
+ (RatingSleepDialog*)createView;
- (void)showInView:(UIView*)parentView;
- (void)hiddenInView;
@end
