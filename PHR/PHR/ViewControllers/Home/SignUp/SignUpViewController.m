//
//  SignUpViewController.m
//  PHR
//
//  Created by SonNV1368 on 9/30/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "SignUpViewController.h"
#import "ConfirmSignUpForgotViewController.h"
#import "IQActionSheetPickerView.h"
#import "NSString+Extension.h"
#import "FacebookProfile.h"
#import "IQKeyboardManager.h"

@interface SignUpViewController () <IQActionSheetPickerViewDelegate, UITextFieldDelegate>{
  UIColor *colorRequired;
  BOOL isLoginFacebook;
  BOOL isHideStatusBar;
}
@property (nonatomic, strong) Profile *profile;
@property (nonatomic, strong) FacebookProfile *facebookProfile;

@end

@implementation SignUpViewController
NSString* token;

- (void)viewDidLoad {
  [super viewDidLoad];
  [self setupUI];
  [self setupStatusBar];
  self.profile = [[Profile alloc] init];
  self.facebookProfile = [[FacebookProfile alloc] init];
  self.comboboxGender.delegateSelectItem = self;
  // Register tap gesture
  UITapGestureRecognizer *gestureRecognizer = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(hideKeyboard)];
  gestureRecognizer.cancelsTouchesInView = YES;
  [self.view addGestureRecognizer:gestureRecognizer];
  
  isHideStatusBar = YES;
  
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}
-(void)viewWillAppear:(BOOL)animated{
  [super viewWillAppear:animated];
  self.navigationController.navigationBarHidden = YES;
}

- (void)viewDidAppear:(BOOL)animated{
  [super viewDidAppear:animated];
  //[[IQKeyboardManager sharedManager] setEnableAutoToolbar:NO];
  [self.textFieldName becomeFirstResponder];
}

- (void)viewDidDisappear:(BOOL)animated {
  [super viewDidDisappear:animated];
  // [[IQKeyboardManager sharedManager] setEnableAutoToolbar:YES];
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

#pragma mark - Setup UI
// Setup UI
- (void)setupUI {
  self.labelPersonal.text = kLocalizedString(kHealthCareRecorder);
  self.labelHealthRecord.text = kLocalizedString(konKCCK);
  self.labelOr.text = kLocalizedString(kOr);
  self.labelAProductOf.text = kLocalizedString(kAProductOfKarteClinic);
  [self setupNavigationBarForSignInTitle:kLocalizedString(kTitleRegister)];
  [self.comboboxGender setArrayChoices:@[kLocalizedString(kSignUpMale), kLocalizedString(kSignUpFemale)]];
  [self.buttonRegisterWithFacebook setTitle:kLocalizedString(kRegisterWithFacebook) forState:UIControlStateNormal];
  
  //UIImage *newImg = [UIImage imageNamed:@"BGHome"];
  //self.imageBackground.image = [newImg applyLightEffect];
  
  [self.labelMessageTerm setText:@""];
  [self.labelMessageTerm setTextColor:PHR_COLOR_TEXT_MEDICINES];
  // Textfield placeholder
  [self.textFieldName setPlaceholder:kLocalizedString(kName)];
  [self.textFieldBirthday setPlaceholder:kLocalizedString(kBirthday)];
  [self.textFieldEmail setPlaceholder:kLocalizedString(kEmail)];
  
  // Button back - submit
  [self.buttonSubmit setBackgroundColor:[UIColor colorWithRed:36.0/255.0 green:176.0/255.0 blue:153.0/255.0 alpha:1.0]];
  [self.buttonSubmit setTitle:kLocalizedString(kTitleRegister) forState:UIControlStateNormal];
  
  // Name kana - just avaiable on JP localtion
  BOOL isLanguageJP = [NSUtils checkJPLanguage];
  self.constraintTextNicknameTop.constant = isLanguageJP ? 37 : 1;
  
  colorRequired = [UIColor colorWithRed:255./255. green:134./255. blue:25./255. alpha:1];
  [self setupTextFieldRightIcon];
}

#pragma mark - Move view
//static const double kOffsetForKeyboard = 260;
- (void)setViewMovedUp:(BOOL)isUp{
  //    [UIView animateWithDuration:0.3f delay:0 options:UIViewAnimationOptionCurveEaseOut animations:^(){
  //        self.constraintBottomSpace.constant = isUp ? kOffsetForKeyboard : 0;
  //        [self.viewButtonControl layoutIfNeeded];
  //    }completion:nil];
}

#pragma mark - Hide Title abd Button Back view
- (void)setHideTitleAndButtonBack:(BOOL)isHide{
  self.navBar.labelTitle.hidden = isHide;
  self.navBar.buttonBack.hidden = isHide;
}

#pragma mark - Textfield delegate
// Textfield delegate
-(BOOL)textFieldShouldReturn:(UITextField *)textField{
  if (textField == self.textFieldName) {
    [self actionDateOfBirth:nil];
    
  }
  if (textField==self.textFieldEmail) {
    [textField resignFirstResponder];
  }
  [self setViewMovedUp:NO];
  //  [self setHideTitleAndButtonBack:NO];
  [self setHideStatusBar:NO];
  
  return YES;
}

- (BOOL)textFieldShouldBeginEditing:(UITextField *)textField{
  [self setViewMovedUp:YES];
  //  [self setHideTitleAndButtonBack:YES];
  
  if (textField == _textFieldName) {
    [self setHideStatusBar:YES];
  }
  
  return YES;
}

- (BOOL)prefersStatusBarHidden {
  return isHideStatusBar;
}

- (void)setHideStatusBar:(BOOL)isHide{
  isHideStatusBar = isHide;
  [[UIApplication sharedApplication] setStatusBarHidden:isHide];
  [self setNeedsStatusBarAppearanceUpdate];
}


- (void)hideKeyboard {
  if ([self.textFieldName isFirstResponder]) {
    [self.textFieldName resignFirstResponder];
  }
  else if ([self.textFieldEmail isFirstResponder]) {
    [self.textFieldEmail resignFirstResponder];
  }
  [self setViewMovedUp:NO];
  // [self setHideTitleAndButtonBack:NO];
  [self setHideStatusBar:NO];
  
}

- (void)textFieldDidEndEditing:(UITextField *)textField{
  [self setViewMovedUp:NO];
  //  [self setHideTitleAndButtonBack:NO];
  [self setHideStatusBar:NO];
}


#pragma mark - UI Actions
// UI Actions
- (IBAction)actionDateOfBirth:(id)sender {
  [self hideKeyboard];
  // Date picker
  IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:kLocalizedString(kBirthday) delegate:self];
  [picker setTag:6];
  [picker setActionSheetPickerStyle:IQActionSheetPickerStyleDatePicker];
  [picker setDate:[self getDefaultDate]];
  [picker setMaximumDate:[NSDate date]];
  [picker show];
}

- (NSDate*) getDefaultDate {
  NSDate *currentDate = [NSDate date];
  NSUInteger componentFlags = NSCalendarUnitYear;
  NSDateComponents *components = [[NSCalendar currentCalendar] components:componentFlags fromDate:currentDate];
  [components setYear:-35];
  return  [[NSCalendar currentCalendar] dateByAddingComponents:components toDate:currentDate  options:0];
}

- (IBAction)pressButtonSignUp:(id)sender {
  [self hideKeyboard];
  // Verify name
  NSString *name = self.textFieldName.text;
  if (!name || [name isEmpty]) {
    [self changeTextFieldColor:colorRequired withTextField:self.textFieldName andText:kLocalizedString(kName) ];
    //[NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kNameInvalid)];
    return;
  }
  
  //    // Verify name Kana
  //    BOOL isLanguageJP = [NSUtils checkJPLanguage];
  //    NSString *nameKana = self.textFieldNameKana.text;
  //    if (isLanguageJP && (!nameKana || [nameKana isEmpty])) {
  //        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kNameKanaInvalid)];
  //        return;
  //    }
  
  // Verify birthday
  NSString *birthday = self.textFieldBirthday.text;
  if (!birthday || [birthday isEmpty]) {
    //[NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kBirthdayInvalid)];
    [self changeTextFieldColor:colorRequired withTextField:self.textFieldBirthday andText:kLocalizedString(kBirthday) ];
    return;
  }
  
  // Verify gender
  NSString *gender = self.comboboxGender.text;
  if (!gender || [gender isEmpty]) {
    //[NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kGenderInvalid)];
    [self changeTextFieldColor:colorRequired withTextField:self.comboboxGender andText:kLocalizedString(kGender) ];
    return;
  }
  
  // Verify email
  NSString *email = self.textFieldEmail.text;
  if (!email || [email isEmpty] || ![email validateEmail]) {
    [self changeTextFieldColor:colorRequired withTextField:self.textFieldEmail andText:kLocalizedString(kEmail) ];
    //[NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kEmailInvalid)];
    return;
  }
  
  //Verify Length
  if (email.length > 128 || name.length > 30) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTextInputLong)];
    return;
  }
  
  if (!isLoginFacebook) {
    // Create profile
    self.profile.email = email;
    self.profile.name = name;
    self.profile.gender = self.comboboxGender.text;
    
    // Request register
    [PHRAppDelegate showLoading];
    [[PHRClient instance] requestRegisterWithProfile:self.profile completed:^(id params){
      [PHRAppDelegate hideLoading];
      // Success
      [NSUtils removeObjectForKey:PHRJNKeyChainPass];
      [NSUtils removeObjectForKey:PHRJNKeyChainEmail];
      BOOL status = [PHRClient getStatusFromResponse:params];
      if (!status) {
        NSString *message = [PHRClient getMessageFromResponse:params];
        [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
      } else {
        NSString *string = [NSString stringWithFormat:kLocalizedString(kSignUpSuccessMessage), email];
        ConfirmSignUpForgotViewController *controller = [[ConfirmSignUpForgotViewController alloc] initWithNibName:NSStringFromClass([ConfirmSignUpForgotViewController class]) bundle:nil];
        [controller setupType:ConfirmTypeSignup andNoticeMessage:string];
        [NSUtils setValue:email forKey:PHRJNKeyChainEmail];
        [self.navigationController pushViewController:controller animated:YES];
      }
    } error:^(NSString *error){
      [PHRAppDelegate hideLoading];
      if ([kLocalizedString(error) isEqualToString:error]) {
        [NSUtils showMessage:kLocalizedString(@"register.fail") withTitle:APP_NAME];
      } else {
        [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
      }
    }];
  } else {
    if(gender != nil && [gender length] > 0){
      gender = [[gender substringToIndex:1] uppercaseString];
    }
    self.facebookProfile.gender = gender;
    self.facebookProfile.email = email;
    [self requestRegisterWithFaceBook];
  }
}


#pragma mark - Action sheet date picker delegate
// Action sheet date picker delegate
- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectDate:(NSDate*)date{
  [self.textFieldBirthday setText:[UIUtils stringyyyyMMddFromDate:date]];
  self.textFieldBirthday.rightViewMode = UITextFieldViewModeNever;
  if(isLoginFacebook) {
    self.facebookProfile.birthday = date;
  } else {
    self.profile.birthday = date;
  }
  [self.comboboxGender onClicked];
}

- (void)didSelectItem {
  [self.textFieldEmail becomeFirstResponder];
}


- (IBAction)pressButtonRegisterWithFacebook:(id)sender {
  FBSDKLoginManager *login = [[FBSDKLoginManager alloc] init];
  login.loginBehavior = FBSDKLoginBehaviorSystemAccount;
  [login logOut];
  
  [login logInWithReadPermissions: @[@"public_profile",@"email",@"user_birthday"]
               fromViewController:self
                          handler:^(FBSDKLoginManagerLoginResult *result, NSError *error) {
                            if (error) {
                              NSLog(@"Process error");
                            } else if (result.isCancelled) {
                              NSLog(@"Cancelled");
                            } else {
                              [self fetchUserInfo];
                            }
                          }];
}

- (void)fetchUserInfo {
  if ([FBSDKAccessToken currentAccessToken]) {
    [[[FBSDKGraphRequest alloc] initWithGraphPath:@"me" parameters:@{@"fields": @"id, name, picture.type(large), email, birthday, gender"}]
     startWithCompletionHandler:^(FBSDKGraphRequestConnection *connection, id result, NSError *error) {
       
       if (!error) {
         token =[[FBSDKAccessToken currentAccessToken] tokenString];
         if(!token){
           return;
         }
         isLoginFacebook = true;
         NSLog(@"result : %@ -- Token %@",result,token);
         NSString *facebookID = result[KEY_ID];
         NSString *name = result[KEY_Name];
         NSString *profileImageURL = result[KEY_Picture][KEY_Data][KEY_URL];
         NSString *email = @"";
         NSString *birthday;
         NSString *gender;
         NSDate *dateFormat;
         if (result && result[KEY_Email] != [NSNull null]) {
           email =  result[KEY_Email];
         }
         if (result && result[KEY_Birthday] != [NSNull null]) {
           birthday =  result[KEY_Birthday];
         }
         if (result && result[KEY_Gender] != [NSNull null]) {
           gender =  result[KEY_Gender];
         }
         
         NSArray *listDateFormat = @[FACEBOOK_BIRTHDAY_TIME_FORMAT_MONTH_DAY_YEAR,FACEBOOK_BIRTHDAY_TIME_FORMAT_YEAR,FACEBOOK_BIRTHDAY_TIME_FORMAT_MONTH_DAY];
         BOOL isBirthdayCorrectFormat = NO;
         if(birthday != nil){
           NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
           for (int i = 0; i < listDateFormat.count; i++) {
             [dateFormatter setDateFormat:[listDateFormat objectAtIndex:i]];
             [dateFormatter setTimeZone:[NSTimeZone timeZoneForSecondsFromGMT:0]];
             dateFormat = [dateFormatter dateFromString:birthday];
             if(dateFormat != nil && i == 0){ // hard code 0 == "MM/dd/yyyy"
               isBirthdayCorrectFormat = YES;
               // If birthday is full infomation so change it to other format yyyy/MM/dd
               //                             [dateFormatter setDateFormat:PHR_BIRTHDAY_SERVER_FORMAT];
               //                             birthday = [dateFormatter stringFromDate:dateFormat];
               break;
             }
           }
         }
         
         //create facebook profile
         self.facebookProfile.token = token;
         self.facebookProfile.facebookID  = facebookID;
         self.facebookProfile.name = name;
         self.facebookProfile.email = email;
         self.facebookProfile.birthday = dateFormat;
         self.facebookProfile.gender = [[gender substringToIndex:1] uppercaseString];
         self.facebookProfile.profileImageURL = profileImageURL;
         //Fill textfield
         [self.buttonRegisterWithFacebook setBackgroundImage:[UIImage imageNamed:@"Bg_Disable_Button"]
                                                    forState:UIControlStateDisabled];
         [self.buttonRegisterWithFacebook setImage: [UIImage imageNamed:@"Icon_Facebook"]
                                          forState:UIControlStateDisabled];
         [self.buttonRegisterWithFacebook setEnabled:false];
         
         //Gender
         if(gender == nil){
           [self changeTextFieldColor:colorRequired withTextField:self.comboboxGender andText:kLocalizedString(kGender) ];
           
         } else {
           if([[gender lowercaseString] isEqualToString:@"male"]) {
             [self.comboboxGender setText:kLocalizedString(kSignUpMale)];
           } else {
             [self.comboboxGender setText:kLocalizedString(kSignUpFemale)];
           }
         }
         //Birthday
         if (isBirthdayCorrectFormat) {
           NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
           [formatter setDateStyle:NSDateFormatterMediumStyle];
           [formatter setTimeStyle:NSDateFormatterNoStyle];
           self.textFieldBirthday.text = [formatter stringFromDate:dateFormat];
         } else {
           [self changeTextFieldColor:colorRequired withTextField:self.textFieldBirthday andText:kLocalizedString(kBirthday)];
         }
         //Email
         if (email == nil){
           [self changeTextFieldColor:colorRequired withTextField:self.textFieldEmail andText:kLocalizedString(kEmail)];
           
         } else {
           self.textFieldEmail.text = email;
         }
         //Name
         if (name == nil) {
           [self changeTextFieldColor:colorRequired withTextField:self.textFieldName andText:kLocalizedString(kName)];
           
         } else {
           self.textFieldName.text = name;
         }
         
         if(name && email && isBirthdayCorrectFormat && gender) {
           [self requestRegisterWithFaceBook];
         }
         //                 //Add more information if lack
         //                 if (gender == nil || isBirthdayCorrectFormat == NO) {
         //                     if(isBirthdayCorrectFormat == YES){
         //                         self.additionalInformationView.birthday = birthday;
         //                     }
         //                     self.additionalInformationView.gender = gender;
         //                    [self.additionalInformationView showInView:self.view];
         //                 } else {
         //                    [self requestRegisterWithFaceBook];
         //                 }
       }
     }];
  }
}

#pragma mark - Request API Register with Facebook
- (void)requestRegisterWithFaceBook {
  [PHRAppDelegate showLoading];
  [[PHRClient instance] requestRegisterWithFaceBook:self.facebookProfile completed:^(id params) {
    BOOL status = [PHRClient getStatusFromResponse:params];
    [PHRAppDelegate hideLoading];
    NSLog(@"%@",params);
    if (!status) {
      [NSUtils showMessage:kLocalizedString(kLoginFail) withTitle:APP_NAME];
    } else {
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
    DLog(@"%@", error);
  }];
}

- (void)setupTextFieldRightIcon {
  //Right icon birthday
  UIImageView *rightIconTextFieldBirthday = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"Icon_Information"]];
  rightIconTextFieldBirthday.frame = CGRectMake(0,0, rightIconTextFieldBirthday.image.size.width - 50.0, rightIconTextFieldBirthday.image.size.height);
  rightIconTextFieldBirthday.contentMode = UIViewContentModeCenter;
  
  self.textFieldBirthday.rightViewMode = UITextFieldViewModeNever;
  self.textFieldBirthday.rightView = rightIconTextFieldBirthday;
  
  //Right icon email
  UIImageView *rightIconTextFieldEmail = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"Icon_Information"]];
  rightIconTextFieldEmail.frame = CGRectMake(0,0, rightIconTextFieldEmail.image.size.width - 50.0, rightIconTextFieldEmail.image.size.height);
  rightIconTextFieldEmail.contentMode = UIViewContentModeCenter;
  
  self.textFieldEmail.rightViewMode = UITextFieldViewModeNever;
  self.textFieldEmail.rightView = rightIconTextFieldEmail;
  
  //Right icon name
  UIImageView *rightIconTextFieldName = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"Icon_Information"]];
  rightIconTextFieldName.frame = CGRectMake(0,0, rightIconTextFieldName.image.size.width - 50.0, rightIconTextFieldName.image.size.height);
  rightIconTextFieldName.contentMode = UIViewContentModeCenter;
  self.textFieldName.rightViewMode = UITextFieldViewModeNever;
  self.textFieldName.rightView = rightIconTextFieldName;
  
  //Right icon gender
  UIImageView *rightIconGender = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"Icon_Information"]];
  rightIconGender.frame = CGRectMake(0,0, rightIconGender.image.size.width - 50.0, rightIconGender.image.size.height);
  rightIconGender.contentMode = UIViewContentModeCenter;
  self.comboboxGender.rightViewMode = UITextFieldViewModeNever;
  self.comboboxGender.rightView = rightIconGender;
  
  //event
  self.textFieldEmail.delegate = self;
  self.textFieldName.delegate = self;
  
  
  [self.textFieldName addTarget:self
                         action:@selector(textDidChange:)
               forControlEvents:UIControlEventEditingChanged];
  
  [self.textFieldEmail addTarget:self
                          action:@selector(textDidChange:)
                forControlEvents:UIControlEventEditingChanged];
  
  [self.comboboxGender setOnTextChange:^(NSString* text) {
    self.comboboxGender.rightViewMode = UITextFieldViewModeNever;
  }];
  
  
}



- (void)textDidChange :(UITextField *)textField {
  if(textField == self.textFieldEmail) {
    if(![self.textFieldEmail.text isEqualToString:@""]){
      self.textFieldEmail.rightViewMode = UITextFieldViewModeNever;
    }
  } else if (textField == self.textFieldName) {
    if(![self.textFieldName.text isEqualToString:@""]){
      self.textFieldName.rightViewMode = UITextFieldViewModeNever;
    }
  }
}


- (void)changeTextFieldColor: (UIColor*)color withTextField:(UITextField*)textfield andText:(NSString*)text {
  textfield.attributedPlaceholder = [[NSAttributedString alloc] initWithString:text attributes:@{NSForegroundColorAttributeName: color}];
  textfield.rightViewMode = UITextFieldViewModeAlways;
}

- (UIStatusBarStyle)preferredStatusBarStyle {
  return UIStatusBarStyleDefault;
}

@end
