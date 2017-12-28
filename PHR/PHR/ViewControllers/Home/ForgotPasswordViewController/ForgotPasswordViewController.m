//
//  ForgotPasswordViewController.m
//  PHR
//
//  Created by SonNV1368 on 9/30/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "ForgotPasswordViewController.h"
#import "ConfirmSignUpForgotViewController.h"
#import "NSString+Extension.h"

@interface ForgotPasswordViewController ()

@end

@implementation ForgotPasswordViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setupUI];
    [self setupStatusBar];
    
    // Register gesture
    UITapGestureRecognizer *gestureRecognizer = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(hideKeyboard)];
    gestureRecognizer.cancelsTouchesInView = YES;
    [self.view addGestureRecognizer:gestureRecognizer];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    self.navigationController.navigationBarHidden = YES;
}

- (void) setupUI {
    UIImage *newImg = [UIImage imageNamed:@"BGHome"];
    self.imageBackground.image = [newImg applyLightEffect];
    
    [self.buttonBack setTitle:kLocalizedString(kBack) forState:UIControlStateNormal];
    [self.buttonSent setTitle:kLocalizedString(kSent) forState:UIControlStateNormal];
    
    [self.textFieldMail setPlaceholder:kLocalizedString(kEmail)];
    self.labelDescription.text = kLocalizedString(kForgotPasswordDescription);
}

#pragma mark - Textfield delegate

-(BOOL)textFieldShouldReturn:(UITextField *)textField {
    [textField resignFirstResponder];
    return YES;
}

- (void)hideKeyboard {
    if ([self.textFieldMail isFirstResponder]) {
        [self.textFieldMail resignFirstResponder];
    }
}

#pragma mark - UIAction
- (IBAction)pressButtonBack:(id)sender {
    [self.navigationController popViewControllerAnimated:YES];
}

- (IBAction)pressButtonReset:(id)sender {
    // Verify
    NSString *email = self.textFieldMail.text;
    if (!email ||[email isEmpty] || ![email validateEmail]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kEmailInvalid)];
        return;
    }
    
    if (email.length > 128) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTextInputLong)];
        return;
    }
    // Request
    [[PHRClient instance] requestResetPasswordForEmail:email completed:^(id response){
        // Notice
        ConfirmSignUpForgotViewController *controller = [[ConfirmSignUpForgotViewController alloc] initWithNibName:NSStringFromClass([ConfirmSignUpForgotViewController class]) bundle:nil];
        [controller setupType:ConfirmTypeResetPassword andNoticeMessage:[NSString stringWithFormat:kLocalizedString(kForgotPasswordSuccessMessage), email]];
        [self.navigationController pushViewController:controller animated:YES];
    } error:^(NSString *error){
        [NSUtils showMessage:kLocalizedString(kResetPasswordDescription) withTitle:APP_NAME];
    }];
}
@end
