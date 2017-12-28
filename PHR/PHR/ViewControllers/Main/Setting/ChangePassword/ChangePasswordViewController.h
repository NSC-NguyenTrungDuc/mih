//
//  ChangePasswordViewController.h
//  PHR
//
//  Created by SonNV1368 on 10/9/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface ChangePasswordViewController : Base2ViewController<UITextFieldDelegate>{
    
}
@property (strong, nonatomic) IBOutlet UIButton *buttonBack;
@property (strong, nonatomic) IBOutlet UIButton *buttonNext;
@property (strong, nonatomic) IBOutlet NSLayoutConstraint *constraintViewControlBottom;

@property (strong, nonatomic) IBOutlet UITextField *textFieldOldPassword;
@property (strong, nonatomic) IBOutlet UITextField *textFieldNewPassword;
@property (strong, nonatomic) IBOutlet UITextField *textFieldNewPasswordConfirm;
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;

- (IBAction)touchButtonBack:(id)sender;
- (IBAction)touchButtonNext:(id)sender;

- (void)setPasswordForFirstLogin:(NSString*)pass;

@end
