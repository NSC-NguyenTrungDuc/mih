//
//  PHRBaseViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 10/12/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRBaseViewController.h"
#import "MainViewController.h"
#import "PreLoginViewController.h"
#import "ChangePasswordViewController.h"
#import "SignUpViewController.h"
#import <PureLayout/PureLayout.h>

@interface PHRBaseViewController ()  <UIAlertViewDelegate>

@end

@implementation PHRBaseViewController

- (void)viewDidLoad {
  [super viewDidLoad];
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  self.navigationController.navigationBarHidden = YES;
}

- (UIStatusBarStyle)preferredStatusBarStyle {
  return UIStatusBarStyleLightContent;
}

- (void)viewWillDisappear:(BOOL)animated {
  for (CALayer* layer in [self.view.layer sublayers]) {
    [layer removeAllAnimations];
  }
}

/*
 #pragma mark - Navigation
 
 // In a storyboard-based application, you will often want to do a little preparation before navigation
 - (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
 // Get the new view controller using [segue destinationViewController].
 // Pass the selected object to the new view controller.
 }
 */

- (void)setupStatusBar {
  UIImageView *imageStatusBg = [[UIImageView alloc] initForAutoLayout];
  [imageStatusBg setBackgroundColor:[UIColor colorWithRed:0 green:0 blue:0 alpha:0.2]];
  [self.view addSubview:imageStatusBg];
  [imageStatusBg autoPinEdgeToSuperviewEdge:ALEdgeLeading];
  [imageStatusBg autoPinEdgeToSuperviewEdge:ALEdgeTop];
  [imageStatusBg autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
  [imageStatusBg autoSetDimension:ALDimensionHeight toSize:20];
}

- (UIButton*)createButtonHeaderWithTitle:(NSString *)title {
  CGFloat btnHeight = 40;
  UIButton *header = [[UIButton alloc] initWithFrame:CGRectMake(0, 0, 0, btnHeight)];
  [header setBackgroundImage:[UIImage imageNamed:@"BtnProfile"] forState:UIControlStateNormal];
  header.contentHorizontalAlignment = UIControlContentHorizontalAlignmentLeft;
  
  // Arrow
  UIImageView *arrow = [[UIImageView alloc] initForAutoLayout]; //initWithFrame:CGRectMake(SCREEN_WIDTH - 25.0, btnHeight / 2 - 3.0, 8.0, 8.0)];
  arrow.image = [UIImage imageNamed:@"ArrowDown"];
  [header addSubview:arrow];
  [arrow autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:10];
  [arrow autoAlignAxisToSuperviewAxis:ALAxisHorizontal];
  [arrow autoSetDimension:ALDimensionWidth toSize:8];
  [arrow autoSetDimension:ALDimensionHeight toSize:8];
  
  // Title
  UILabel *labelTitle = [[UILabel alloc] initForAutoLayout];
  labelTitle.text = title;
  [labelTitle setFont:[FontUtils aileronRegularWithSize:14.0]];
  [labelTitle setTextColor:RGBCOLOR(75.0, 75.0, 75.0)];
  [header addSubview:labelTitle];
  [labelTitle autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:10];
  [labelTitle autoAlignAxisToSuperviewAxis:ALAxisHorizontal];
  [labelTitle autoPinEdge:ALEdgeTrailing toEdge:ALEdgeLeading ofView:arrow];
  [labelTitle autoSetDimension:ALDimensionHeight toSize:btnHeight];
  
  return header;
}


- (void)setupNavigationBarTitle:(NSString *)title titleIcon:(NSString *)titleIcon rightItem:(NSString *)rightItem {
  __weak __typeof__(self) weakSelf = self;
  
  // Custom navigation bar
  self.navBar = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([Base2NavigationBar class]) owner:self options:nil] objectAtIndex:0];
  [self.navBar setupWithTitle:title icon:titleIcon rightItem:rightItem];
  [self.view addSubview:self.navBar];
  
  [self.navBar autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
  [self.navBar autoPinEdgeToSuperviewEdge:ALEdgeLeading];
  [self.navBar autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
  [self.navBar autoSetDimension:ALDimensionHeight toSize:60];
  // back
  [self.navBar setActionBack:^(){
    [weakSelf.navigationController popViewControllerAnimated:YES];
  }];
  
  // right action
  [self.navBar setActionRight:^(){
    [weakSelf.navigationController popViewControllerAnimated:YES];
  }];
  
  if (rightItem == nil) {
    [self.navBar.imgPortraitLine setHidden:YES];
  }
}

- (void)setupNavigationBarForSignInTitle:(NSString *)title{
  __weak __typeof__(self) weakSelf = self;
  
  // Custom navigation bar
  self.navBar = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([Base2NavigationBar class]) owner:self options:nil] objectAtIndex:0];
  [self.navBar setupForSiginWithTitle:title];
  [self.view addSubview:self.navBar];
  
  [self.navBar autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
  [self.navBar autoPinEdgeToSuperviewEdge:ALEdgeLeading];
  [self.navBar autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
  [self.navBar autoSetDimension:ALDimensionHeight toSize:60];
  // back
  [self.navBar setActionBack:^(){
    [weakSelf.navigationController popViewControllerAnimated:YES];
  }];
  
  // right action
  [self.navBar setActionRight:^(){
    [weakSelf.navigationController popViewControllerAnimated:YES];
  }];
}


#pragma mark - Handle common function
/*
 LOGIN SUCCESS
 - Load data
 - Move to dashboard
 */
- (void)handleLoginSuccess {
  __block BOOL loadStandard = NO, loadBaby = NO;
  [PHRAppDelegate showLoading];
  [[PHRClient instance] requestStandardProfileListCompleted:^(id response){
    loadStandard = YES;
    [PHRAppStatus parseStandardProfilesResponse:response];
    [self checkLoadedStandard:loadStandard baby:loadBaby];
  } error:^(NSString *error){
    [PHRAppDelegate hideLoading];
  }];
  
  [[PHRClient instance] requestBabyProfileListCompleted:^(id response){
    loadBaby = YES;
    [PHRAppStatus parseBabyProfilesResponse:response];
    [self checkLoadedStandard:loadStandard baby:loadBaby];
  } error:^(NSString *error){
    [PHRAppDelegate hideLoading];
  }];
}


- (void)checkLoadedStandard:(BOOL)standard baby:(BOOL)baby {
  if (standard & baby) {
    [PHRAppDelegate hideLoading];
    // Login
    MainViewController *main = [[MainViewController alloc] initMainController];
    [self.navigationController pushViewController:main animated:YES];
    
  }
}

#pragma mark - Request API
- (void)requestLoginWithEmail:(NSString*)email password:(NSString*)password {
  [PHRAppDelegate showLoading];
  [[PHRClient instance] requestLoginWithEmail:email password:password completed:^(id params){
    BOOL status = [PHRClient getStatusFromResponse:params];
    [PHRAppDelegate hideLoading];
    // get user info
    PHRAppStatus.accountId = [PHRClient getAccountIDFromResponse:params];
    PHRAppStatus.masterProfileId = [PHRClient getMasterProfileIDFromResponse:params];
    
    if (!status) {
      [PHRAppDelegate hideLoading];
      NSString *message = [PHRClient getMessageFromResponse:params];
      if ([message isEqualToString:RESULT_FirstChangePassRequired]) {
        [self showPreLoginWithEmail:email andPassword:password];
      } else{
        [NetworkManager clearSavedPassword];
        [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
      }
    } else {
      NSString *type = [PHRClient getTypeFromResponse:params];
      NSString *activeStatus = [PHRClient getProfileStatusFromResponse:params];
      if ([type isEqualToString:@"0"] && [activeStatus isEqualToString:@"1"]) {
        [self showPreLoginWithEmail:email andPassword:password];
      } else {
        [self handleLoginSuccess];
      }
      // Save  pass
      [NetworkManager saveSettingPassword:password];
    }
    // Save email
    [NetworkManager saveSettingEmail:email];
  } error:^(NSString *error){
    [PHRAppDelegate hideLoading];
  }];
}

#pragma mark - Request API Facebook
- (void)requestLoginWithFacebook:(NSString*)token isAutologin:(BOOL)isAutoLogin {
  [PHRAppDelegate showLoading];
  [[PHRClient instance] requestLoginWithFacebook:token completed:^(id params) {
    BOOL status = [PHRClient getStatusFromResponse:params];
    if (!status) {
      
      [PHRAppDelegate hideLoading];
      NSString *message = [PHRClient getMessageFromResponse:params];
      [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
      [NetworkManager clearSavedFacebookAccessToken];
    } else {
      [PHRAppDelegate hideLoading];
      PHRAppStatus.accountId = [PHRClient getAccountIDFromResponse:params];
      PHRAppStatus.masterProfileId = [PHRClient getMasterProfileIDFromResponse:params];
      NSString *type = [PHRClient getTypeFromResponse:params];
      NSString *status = [PHRClient getProfileStatusFromResponse:params];
      
      if ([type isEqualToString:@"0"] && [status isEqualToString:@"1"]) {
        [self showPreLoginFacebook:token];
      } else {
        [NetworkManager saveSettingFacebookAccessToken:token];
        [self handleLoginSuccess];
      }
    }
  } error:^(NSString *error){
    [PHRAppDelegate hideLoading];
    [NetworkManager clearSavedFacebookAccessToken];
    [NSUtils showMessage:kLocalizedString(kFailLoginFacebook) withTitle:APP_NAME];
    
  }];
  
}

- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex{
  if (buttonIndex == [alertView cancelButtonIndex]){
    [alertView dismissWithClickedButtonIndex:0 animated:YES];
  } else {
    [alertView dismissWithClickedButtonIndex:0 animated:YES];
    SignUpViewController *controller = [[SignUpViewController alloc] initWithNibName:NSStringFromClass([SignUpViewController class]) bundle:nil];
    [self.navigationController pushViewController:controller animated:YES];
  }
}

- (void)showPreLoginWithEmail:(NSString*)email andPassword:(NSString*)password {
  PreLoginViewController *controllerPreLogin = [[PreLoginViewController alloc] initWithNibName:NSStringFromClass([PreLoginViewController class]) bundle:nil];
  controllerPreLogin.isLoginFaceBook = false;
  [self.navigationController pushViewController:controllerPreLogin animated:YES];
  [controllerPreLogin setOnAgreeComplete:^(int mess){
    
    // Change pass
    ChangePasswordViewController *controller = [[ChangePasswordViewController alloc] initWithNibName:NSStringFromClass([ChangePasswordViewController class]) bundle:nil];
    if (password) {
      [controller setPasswordForFirstLogin:password];
    }
    [self.navigationController pushViewController:controller animated:YES];
  }];
  
}

- (void)showPreLoginFacebook:(NSString*)token {
  PreLoginViewController *controllerPreLogin = [[PreLoginViewController alloc] initWithNibName:NSStringFromClass([PreLoginViewController class]) bundle:nil];
  controllerPreLogin.isLoginFaceBook = true;
  [self.navigationController pushViewController:controllerPreLogin animated:YES];
  [controllerPreLogin setOnAgreeComplete:^(int mess){
    [NetworkManager saveSettingFacebookAccessToken:token];
    [self handleLoginSuccess];
  }];
}

@end
