//
//  HomeViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 9/29/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "SignInViewController.h"
#import "SignUpViewController.h"
#import "MainViewController.h"
#import "ForgotPasswordViewController.h"
#import "ChangePasswordViewController.h"
#import "PreLoginViewController.h"
#import "DataManager.h"

@interface SignInViewController (){
  BOOL isHideStatusBar;
}


@end

@implementation SignInViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  // UI
  [self setupUI];
  // Status bar
  [self setupStatusBar];
  
  isHideStatusBar = NO;
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  [self autoFillUsername];
}

- (void)viewWillDisappear:(BOOL)animated {
  [super viewWillDisappear:animated];
  [self.txtPassword setText:@""];
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (void)viewWillLayoutSubviews {
  [super viewWillLayoutSubviews];
  // Gradient
  UIColor *colorOne = [UIColor colorWithRed:1.0f green:1.0f blue:1.0f alpha:1.0f];
  UIColor *colorTwo = [UIColor colorWithRed:1.0f green:1.0f blue:1.0f alpha:0.0f];
  NSArray *colors = [NSArray arrayWithObjects:(id)colorOne.CGColor, colorTwo.CGColor, nil];
  NSNumber *stopOne = [NSNumber numberWithFloat:0.0];
  NSNumber *stopTwo = [NSNumber numberWithFloat:1.0];
  NSArray *locations = [NSArray arrayWithObjects:stopOne, stopTwo, nil];
  
  CAGradientLayer *gradientLayer = [CAGradientLayer layer];
  gradientLayer.frame = self.imageBgGradient.bounds;
  [gradientLayer setStartPoint:CGPointMake(0.5, 1.0)];
  [gradientLayer setEndPoint:CGPointMake(0.5, 0.0)];
  gradientLayer.colors = colors;
  gradientLayer.locations = locations;
  if ([self.imageBgGradient.layer sublayers].count > 0) {
    [self.imageBgGradient.layer replaceSublayer:[self.imageBgGradient.layer sublayers][0] with:gradientLayer];
  }
  else{
    [self.imageBgGradient.layer insertSublayer:gradientLayer atIndex:0];
  }
}

- (void)autoFillUsername {
  NSString *username = [NSUtils valueForKey:PHRJNKeyChainEmail];
  
  if (![UIUtils isNullOrEmpty:username]) {
    [self.txtUsername setText:username];
  }
  else {
    [self.txtUsername setText:PHR_STR_NULL];
  }
}

- (void)setupUI {
  self.labelPersonal.text = kLocalizedString(kHealthCareRecorder);
  self.labelHealthRecord.text = kLocalizedString(konKCCK);
  self.labelAProductOf.text = kLocalizedString(kAProductOfKarteClinic);
  [self setupNavigationBarForSignInTitle:kLocalizedString(kSignIn)];
  
  [self.btnSignIn setTitle:kLocalizedString(kSignIn) forState:UIControlStateNormal];
  [self.btnSignInByFacebook setTitle:kLocalizedString(kSignInByFacebook) forState:UIControlStateNormal];
  [self.btnForgotPassword setTitle:kLocalizedString(kForgotPassword) forState:UIControlStateNormal];
  
  [self.txtUsername setAutocorrectionType:UITextAutocorrectionTypeNo];
  [self.txtPassword setAutocorrectionType:UITextAutocorrectionTypeNo];
  
  [self.txtUsername setPlaceholder:kLocalizedString(kEmail)];
  [self.txtPassword setPlaceholder:kLocalizedString(kPassword)];
  
  //Right Icon for textfield
  UIImageView *rightIconTextFieldUsername = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"Icon_Email"]];
  rightIconTextFieldUsername.frame = CGRectMake(0,0, rightIconTextFieldUsername.image.size.width - 50.0, rightIconTextFieldUsername.image.size.height);
  rightIconTextFieldUsername.contentMode = UIViewContentModeCenter;
  self.txtUsername.rightViewMode = UITextFieldViewModeAlways;
  self.txtUsername.rightView = rightIconTextFieldUsername;
  
  UIImageView *rightIconTextFieldPassword = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"Icon_Lock"]];
  rightIconTextFieldPassword.frame = CGRectMake(0,0, rightIconTextFieldPassword.image.size.width - 50.0, rightIconTextFieldPassword.image.size.height);
  rightIconTextFieldPassword.contentMode = UIViewContentModeCenter;
  self.txtPassword.rightViewMode = UITextFieldViewModeAlways;
  self.txtPassword.rightView = rightIconTextFieldPassword;
}



#pragma mark -  Method Sign In

- (UIStatusBarStyle)preferredStatusBarStyle {
  return UIStatusBarStyleDefault;
}

- (IBAction)pressBtnSignIn:(id)sender {
  if (!self.txtUsername.text || self.txtUsername.text.length == 0) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kSignInMissEmail)];
    return;
  }
  if (!self.txtPassword.text || self.txtPassword.text.length == 0) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kSignInMissPassword)];
    return;
  }
  
  if (![self.txtUsername.text validateEmail]) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kInvalidEmail)];
    return;
  }
  
  if (self.txtUsername.text.length > 128 || self.txtPassword.text.length > 128) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTextInputLong)];
    return;
  }
  
  // Request login
  [self requestLoginWithEmail:self.txtUsername.text password:self.txtPassword.text];
}

- (IBAction)pressButtonForgotPassword:(id)sender {
  ForgotPasswordViewController *forgotPasswordViewController = [[ForgotPasswordViewController alloc] initWithNibName:NSStringFromClass([ForgotPasswordViewController class]) bundle:nil];
  [self.navigationController pushViewController:forgotPasswordViewController animated:YES];
  
}

- (IBAction)pressButtonFB:(id)sender {
  FBSDKLoginManager *login = [[FBSDKLoginManager alloc] init];
  login.loginBehavior = FBSDKLoginBehaviorSystemAccount;
  [login logOut];
  
  [login logInWithReadPermissions: @[@"public_profile",@"email",@"user_birthday"]
               fromViewController:self
                          handler:^(FBSDKLoginManagerLoginResult *result, NSError *error) {
                            if (error) {
                              if (error.code == 306) {
                                [NSUtils showMessage:kLocalizedString(kFBNotAccessSystemSetting) withTitle:APP_NAME];
                              }
                            } else if (result.isCancelled) {
                              NSLog(@"Cancelled");
                            } else {
                              [self fetchUserInfo];
                            }
                          }];
}

#pragma mark - Textfield delegate
- (BOOL)textFieldShouldReturn:(UITextField *)textField {
  if (textField == self.txtUsername) {
    [self.txtPassword becomeFirstResponder];
  }
  else if (textField == self.txtPassword) {
    [self.txtPassword resignFirstResponder];
  }
  return YES;
}

- (void)textFieldDidBeginEditing:(UITextField *)textField{
  if (textField.tag == 12) {
    //    self.navBar.labelTitle.hidden = YES;
    //    self.navBar.buttonBack.hidden = YES;
    [self setHideStatusBar:YES];
  }else{
    //    self.navBar.labelTitle.hidden = NO;
    //    self.navBar.buttonBack.hidden = NO;
    [self setHideStatusBar:NO];
  }
}

- (BOOL)prefersStatusBarHidden {
  
  return isHideStatusBar;
}

- (void)setHideStatusBar:(BOOL)isHide{
  isHideStatusBar = isHide;
  [[UIApplication sharedApplication] setStatusBarHidden:isHide];
  [self setNeedsStatusBarAppearanceUpdate];
  // [self prefersStatusBarHidden];
}

- (void)textFieldDidEndEditing:(UITextField *)textField{
  //  self.navBar.labelTitle.hidden = NO;
  //  self.navBar.buttonBack.hidden = NO;
  [self setHideStatusBar:NO];
}

- (void)dealloc {
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)fetchUserInfo {
  if ([FBSDKAccessToken currentAccessToken]) {
    [[[FBSDKGraphRequest alloc] initWithGraphPath:@"me" parameters:@{@"fields": @"id,name,picture.type(large), email, birthday,gender"}]
     startWithCompletionHandler:^(FBSDKGraphRequestConnection *connection, id result, NSError *error) {
       if (!error) {
         NSString* token =[[FBSDKAccessToken currentAccessToken] tokenString];
         if(token == nil){
           return;
         }
         [self requestLoginWithFacebook:token isAutologin:false];
       }
     }];
  }
}



@end
