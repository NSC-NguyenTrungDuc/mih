//
//  SignUpViewController.h
//  PHR
//
//  Created by SonNV1368 on 9/30/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PHRBaseViewController.h"
#import <FBSDKCoreKit/FBSDKCoreKit.h>
#import <FBSDKLoginKit/FBSDKLoginKit.h>
#import "PreLoginViewController.h"
#import "PHRButtonComboboxNoLine.h"


@interface SignUpViewController : PHRBaseViewController <UITextFieldDelegate,PHRButtonComboboxNoLineDelegate>

@property (strong, nonatomic) IBOutlet UIImageView *imageBackground;
@property (strong, nonatomic) IBOutlet UITextField *textFieldName;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTextNicknameTop;
@property (weak, nonatomic) IBOutlet UILabel *labelPersonal;
@property (weak, nonatomic) IBOutlet UILabel *labelHealthRecord;
@property (weak, nonatomic) IBOutlet UILabel *labelOr;

@property (weak, nonatomic) IBOutlet UILabel *labelAProductOf;
@property (weak, nonatomic) IBOutlet UITextField *textFieldBirthday;

//@property (strong, nonatomic) IBOutlet UITextField *textFieldGender;


@property (strong, nonatomic) IBOutlet UITextField *textFieldEmail;
@property (strong, nonatomic) IBOutlet UILabel *labelMessageTerm;

@property (weak, nonatomic) IBOutlet UIView *viewButtonControl;
@property (strong, nonatomic) IBOutlet UIButton *buttonBack;
@property (strong, nonatomic) IBOutlet UIButton *buttonSubmit;
@property (weak, nonatomic) IBOutlet UIButton *buttonRegisterWithFacebook;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintBottomSpace;
@property (weak, nonatomic) IBOutlet PHRButtonComboboxNoLine *comboboxGender;
@property (weak, nonatomic) IBOutlet UIImageView *imageBgGradient;

- (IBAction)actionDateOfBirth:(id)sender;

- (IBAction)pressButtonSignUp:(id)sender;
- (IBAction)pressButtonRegisterWithFacebook:(id)sender;

@end
