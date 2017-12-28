//
//  ConfirmSignUpForgotViewController.h
//  PHR
//
//  Created by SonNV1368 on 9/30/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PHRBaseViewController.h"

typedef NS_ENUM(NSInteger, ConfirmType) {
    ConfirmTypeFirstLoginChangePassword,
    ConfirmTypeSignup,
    ConfirmTypeResetPassword,
    ConfirmTypeChangePassword,
};

@interface ConfirmSignUpForgotViewController : PHRBaseViewController{
    
}

@property (weak, nonatomic) IBOutlet UIImageView *imageType;

@property (strong, nonatomic) IBOutlet UIImageView *imageBackground;
@property (strong, nonatomic) IBOutlet UILabel *labelMessage;
@property (strong, nonatomic) IBOutlet UIButton *buttonDone;
/*
 Normally, action done will return to Home screen.
 But override this block to replace this action.
 */
@property (copy, nonatomic) void (^done)(void);

- (IBAction)actionDone:(id)sender;
- (void)setupType:(ConfirmType)type andNoticeMessage:(NSString*)notice;

@end
