//
//  ChangePasswordViewController.m
//  PHR
//
//  Created by SonNV1368 on 10/9/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "ChangePasswordViewController.h"
#import "ConfirmSignUpForgotViewController.h"
#import "NSString+Extension.h"

@interface ChangePasswordViewController (){
    
}
@property (nonatomic, strong) NSString *oldPass;
@property (nonatomic, assign) BOOL isFirstLogin;

@end

@implementation ChangePasswordViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setupNavigationBarTitle:kLocalizedString(kChangePasswordTitle) titleIcon:nil rightItem:nil];
    [self setupUI];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}

- (void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    [self setImageToBackground:self.imageBackground];
}

- (void) setupUI{
    [self.textFieldOldPassword setPlaceholder:kLocalizedString(kOldPassword)];
    [self.textFieldNewPassword setPlaceholder:kLocalizedString(kNewPassword)];
    [self.textFieldNewPasswordConfirm setPlaceholder:kLocalizedString(kNewPasswordConfirm)];
    
    [self.buttonBack setTitle:kLocalizedString(kBack) forState:UIControlStateNormal];
    [self.buttonNext setTitle:kLocalizedString(kSubmit) forState:UIControlStateNormal];

    if (self.oldPass) {
        self.textFieldOldPassword.text = self.oldPass;
    }
}

- (void)setPasswordForFirstLogin:(NSString*)pass{
    self.oldPass = pass;
    self.isFirstLogin = YES;
}

#pragma mark - UI Actions

- (IBAction)touchButtonBack:(id)sender {
    [NetworkManager clearSavedPassword];
    [self.navigationController popViewControllerAnimated:YES];
}

- (IBAction)touchButtonNext:(id)sender {
    // Verify email
    NSString *oldPassword = self.textFieldOldPassword.text;
    if (!oldPassword || [oldPassword isEmpty]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kChangePassMissOldPassword)];
        return;
    }
    
    NSString *newPassword = self.textFieldNewPassword.text;
    if (!newPassword || [newPassword isEmpty]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kChangePassMissNewPassword)];
        return;
    }
    
    NSString *newPasswordConfirm = self.textFieldNewPasswordConfirm.text;
    if (!newPasswordConfirm || [newPasswordConfirm isEmpty]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kChangePassMissNewPasswordConfirm)];
        return;
    }
    // Compare new password
    if (![newPassword isEqualToString:newPasswordConfirm]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kChangePassDontMatchPassword)];
        return;
    }
    
    if (newPassword.length > 128 || oldPassword.length > 128 ||newPasswordConfirm.length > 128) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTextInputLong)];
        return;
    }
    
    [PHRAppDelegate showLoading];
    // Request change password
    [[PHRClient instance] requestChangePassword:oldPassword toNewPassword:newPassword completed:^(id response){
        [PHRAppDelegate hideLoading];
        // Change password success
        // Next
        ConfirmType type = (self.isFirstLogin ? ConfirmTypeFirstLoginChangePassword : ConfirmTypeChangePassword);
        ConfirmSignUpForgotViewController *controller = [[ConfirmSignUpForgotViewController alloc] initWithNibName:NSStringFromClass([ConfirmSignUpForgotViewController class]) bundle:nil];
        [controller setupType:type andNoticeMessage:kLocalizedString(kChangePassSuccessMessage)];
        [controller setDone:^(){
            if (type == ConfirmTypeChangePassword) {
                [self.navigationController popToViewController:[[self.navigationController viewControllers] objectAtIndex:2] animated:YES];
            }
            else if (type == ConfirmTypeFirstLoginChangePassword){
                // Like case login success: load data and move to dashboard
                [self handleLoginSuccess];
            }
        }];
        [self.navigationController pushViewController:controller animated:YES];
    }error:^(NSString *error){
        [PHRAppDelegate hideLoading];
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kFailChangePass)];
    }];
}

#pragma mark - Textfield delegate
- (BOOL)textFieldShouldReturn:(UITextField *)textField{
    [textField resignFirstResponder];
    return YES;
}




@end
