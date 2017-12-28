//
//  HomeViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 9/29/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PHRBaseViewController.h"
#import <FBSDKCoreKit/FBSDKCoreKit.h>
#import <FBSDKLoginKit/FBSDKLoginKit.h>

@interface SignInViewController : PHRBaseViewController <UITextFieldDelegate>{
    
}
@property (weak, nonatomic) IBOutlet UIImageView *imageBgGradient;
@property (weak, nonatomic) IBOutlet UILabel *labelPersonal;
@property (weak, nonatomic) IBOutlet UILabel *labelHealthRecord;

@property (weak, nonatomic) IBOutlet UILabel *labelAProductOf;


@property (strong, nonatomic) IBOutlet UITextField *txtUsername;
@property (strong, nonatomic) IBOutlet UITextField *txtPassword;
@property (strong, nonatomic) IBOutlet UIView *view1;

@property (weak, nonatomic) IBOutlet UIButton *btnForgotPassword;
@property (weak, nonatomic) IBOutlet UIButton *btnSignIn;
@property (weak, nonatomic) IBOutlet UIButton *btnSignInByFacebook;


- (IBAction)pressButtonForgotPassword:(id)sender;
- (IBAction)pressButtonFB:(id)sender;



@end
