//
//  ProfileChildrenViewController.m
//  PHR
//
//  Created by SonNV1368 on 10/5/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "ProfileChildrenViewController.h"
#import "IQActionSheetPickerView.h"
#import "NSString+Extension.h"
#import "MainViewController.h"


@interface ProfileChildrenViewController () <IQActionSheetPickerViewDelegate>{
  
}
@property (strong, nonatomic, readonly) ProfileBaby *baby;
@property (assign, nonatomic) BOOL isEditMode;
@property (assign, nonatomic) BOOL changedAvatar;

@end

@implementation ProfileChildrenViewController{
  
}

- (void)viewDidLoad {
  [super viewDidLoad];
  // Do any additional setup after loading the view from its nib.
  [self setupUI];
  [self setupNavigationBarTitle:kLocalizedString(kBabyList) titleIcon:@"icon_title_baby" rightItem:kLocalizedString(kSave)];
  
  // Load data
  if (self.baby && self.baby.profileId) {
    [self getProfileBaby];
  }
  else{
    _baby = [[ProfileBaby alloc] init];
  }
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated{
  [super viewWillAppear:animated];
  [self setImageToBackgroundBaby:self.mainBackground];
  [self.navigationController setToolbarHidden:NO animated:YES];
}

- (void)viewWillDisappear:(BOOL)animated{
  [super viewWillDisappear:animated];
  [self.navigationController setToolbarHidden:YES animated:YES];
}

- (void)showOrHideLoading:(BOOL)isShowed {
  if (isShowed) {
    [self.viewIndicator setHidden:NO];
  } else {
    [self.viewIndicator setHidden:YES];
  }
}

- (void)setProfileBaby:(ProfileBaby*)baby{
  _baby = [[ProfileBaby alloc] initWithProfile:baby];
  self.isEditMode = YES;
  
}

#pragma mark - Init View

- (void) setupUI {
  //placeholder
  self.textFieldName.placeholder = kLocalizedString(kName);
  self.textFieldNameKana.placeholder = kLocalizedString(kNameKana);
  self.textFieldNickName.placeholder = kLocalizedString(kNickname);
  self.textFieldBirthday.placeholder = kLocalizedString(kBirthday);
  self.textFieldHeight.placeholder = kLocalizedString(kGrowthHeight);
  self.textFieldWeight.placeholder = kLocalizedString(kGrowthWeight);
  
  [self.comboboxRelationship setArrayChoices:@[kLocalizedString(kSon), kLocalizedString(kDaughter), kLocalizedString(kNiece), kLocalizedString(kNephew)]];
  self.comboboxRelationship.delegate = self;
}

- (void)fillBabyProfile {
  if (self.baby) {
    self.textFieldName.text = self.baby.name;
    self.textFieldNickName.text = self.baby.nickName;
    self.textFieldNameKana.text = self.baby.nameKana;
    self.textFieldBirthday.text = [NSUtils stringFromDate:self.baby.birthday withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    self.textFieldHeight.text = [NSString stringWithFormat:@"%d",[self.baby.growth.height intValue]];
    self.textFieldWeight.text = [NSString stringWithFormat:@"%d",[self.baby.growth.weight intValue]];
    [self.comboboxRelationship setText:self.baby.relationship];
    // Avatar
    [self.imageAvatar sd_setImageWithURL:[NSURL URLWithString:self.baby.avatar] placeholderImage:[UIImage imageNamed:@"IconCamera"] options:SDWebImageRefreshCached];
  }
}

#pragma mark - Request data
- (void)getProfileBaby {
  [PHRAppDelegate showLoading];
  [[PHRClient instance] requestGetDetailBabyProfileId:self.baby.profileId completed:^(id response){
    [PHRAppDelegate hideLoading];
    if (response && response[KEY_Content] != [NSNull null]) {
      _baby = [[ProfileBaby alloc] initWithDictionary:response[KEY_Content]];
    }
    // Fill data
    [self fillBabyProfile];
  }error:^(NSString *error){
    [PHRAppDelegate hideLoading];
  }];
}


#pragma mark - Method To Left Menu Bar Item

- (void)setDataForMemeberObject {
  if (!self.baby){
    _baby = [[ProfileBaby alloc] init];
  }
  self.baby.name = self.textFieldName.text;
  self.baby.nickName = self.textFieldNickName.text;
  self.baby.nameKana = self.textFieldNameKana.text;
  self.baby.birthday = [self dateFromBirthdayField];
  self.baby.relationship = [self.comboboxRelationship getText];
  self.baby.growth.height = self.textFieldHeight.text;
  self.baby.growth.weight = self.textFieldWeight.text;
  self.baby.isActive = NO;
}

- (BOOL)checkRequire{
  NSString *name = self.textFieldName.text;
  if (!name || [name isEmpty]) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kSignInMissEmail)];
    return NO;
  }
  // Birthday
  if (!self.textFieldBirthday.text || [self.textFieldBirthday.text isEqualToString:@""]) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kPleaseEnterBirthday)];
    return NO;
  }
  if (!self.textFieldNameKana.text || [self.textFieldNameKana.text isEqualToString:@""]) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(@"baby.profile.full.name.kana.required")];
    return NO;
  }
  if (!self.textFieldHeight.text || [self.textFieldHeight.text isEqualToString:@""]) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kInputChildHeight)];
    return NO;
  }
  if (!self.textFieldWeight.text || [self.textFieldWeight.text isEqualToString:@""]) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kInputChildWeight)];
    return NO;
  }
  
  return YES;
}

- (void)actionNavigationBarItemRight{
  if (![self checkRequire]) {
    return;
  }
  [PHRAppDelegate showLoading];
  [self setDataForMemeberObject];
  if (self.changedAvatar) {
    [self processUploadImageInNewThread:self.imageAvatar.image];
    //[self requestUpdateProfileBaby];
  }
  else{
    [self requestUpdateProfileBaby];
  }
}


#pragma mark - UITextFieldDelegate
- (BOOL)textFieldShouldReturn:(UITextField *)textField {
  if (textField == self.textFieldName) {
    [self.textFieldNickName becomeFirstResponder];
  }
  if (textField == self.textFieldNickName) {
    [self.textFieldNameKana becomeFirstResponder];
  }
  if (textField == self.textFieldNameKana) {
    //[self.textFieldWeight becomeFirstResponder];
    [self actionChangeBirthday:nil];
  }
  if (textField == self.textFieldHeight) {
    [self.textFieldWeight becomeFirstResponder];
  }
  if (textField == self.textFieldWeight) {
    [textField resignFirstResponder];
  }
  return YES;
}

#pragma mark - Hanlde Action Button

- (IBAction)touchTakePhoto:(id)sender {
  [NSUtils createPhotoLibrary:self andViewController:self];
  
}

- (void)assetsPickerController:(CTAssetsPickerController *)picker didFinishPickingAssets:(NSArray *)assets
{
  PHImageRequestOptions *requestOptions = [[PHImageRequestOptions alloc] init];
  requestOptions.resizeMode   = PHImageRequestOptionsResizeModeExact;
  requestOptions.deliveryMode = PHImageRequestOptionsDeliveryModeHighQualityFormat;
  
  [assets enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
    PHImageManager *manager = [PHImageManager defaultManager];
    CGFloat scale = UIScreen.mainScreen.scale;
    CGSize targetSize = CGSizeMake(self.imageAvatar.frame.size.height * scale, self.imageAvatar.frame.size.height * scale);
    
    [manager ctassetsPickerRequestImageForAsset:assets[0]
                                     targetSize:targetSize
                                    contentMode:PHImageContentModeAspectFill
                                        options:requestOptions
                                  resultHandler:^(UIImage *image, NSDictionary *info){
                                    self.imageAvatar.image = image;
                                    self.changedAvatar = YES;
                                  }];
  }];
  [picker dismissViewControllerAnimated:YES completion:nil];
  
}

- (BOOL)assetsPickerController:(CTAssetsPickerController *)picker shouldSelectAsset:(PHAsset *)asset
{
  NSInteger max = 1;
  
  // show alert gracefully
  if (picker.selectedAssets.count >= max)
  {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
  }
  
  // limit selection to max
  return (picker.selectedAssets.count < max);
}

- (IBAction)actionChangeBirthday:(id)sender {
  [self.view endEditing:YES];
  // Date picker
  IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:kLocalizedString(kBirthday) delegate:self];
  [picker setTag:1];
  [picker setActionSheetPickerStyle:IQActionSheetPickerStyleDatePicker];
  [picker setDate:(_baby.birthday ? _baby.birthday : [NSDate date])];
  [picker setMaximumDate:[NSDate date]];
  [picker show];
}

- (IBAction)actionChoiceRelationship:(id)sender {
  
}

- (void)uzysAssetsPickerControllerDidExceedMaximumNumberOfSelection:(UzysAssetsPickerController *)picker {
  [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
}

- (void)processUploadImageInNewThread:(UIImage*)newImage {
  __weak __typeof(self) weakSelf = self;
  [[PHRClient instance] uploadProfileImageToServer:newImage andCompletion:^(id responseObject) {
    if (responseObject == nil) {
      dispatch_async(dispatch_get_main_queue(), ^{
        [PHRAppDelegate hideLoading];
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
      });
    }
    else {
      weakSelf.baby.avatar = [Validator getSafeString:responseObject[@"content"]];
      [weakSelf requestUpdateProfileBaby];
    }
  }];
}

- (void)requestUpdateProfileBaby{
  if (self.textFieldName.text.length > 30 || self.textFieldNameKana.text.length > 30 || self.textFieldNickName.text.length > 30 || [self.textFieldHeight.text doubleValue] > 300 || [self.textFieldWeight.text doubleValue] > 300) {
    [NSUtils showMessage:kLocalizedString(kTextInputLong) withTitle:APP_NAME];
    [PHRAppDelegate hideLoading];
    return;
  }
  
  if (self.isEditMode && self.baby.profileId) {
    // Edit
    [[PHRClient instance] requestEditBabyProfile:self.baby completed:^(id response){
      [PHRAppDelegate hideLoading];
      if (response && response[KEY_Content] != [NSNull null]) {
        for (ProfileBaby *profile in PHRAppStatus.arrayBabyProfile) {
          if ([profile.profileId isEqualToString:self.baby.profileId]) {
            [profile updateWithDictionary:response[KEY_Content]];
            break;
          }
        }
      }
      [self.navigationController popViewControllerAnimated:YES];
    }error:^(NSString *error){
      [PHRAppDelegate hideLoading];
      [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
    }];
  }
  else{
    // Add new
    [[PHRClient instance] requestAddNewBabyProfile:self.baby completed:^(id response){
      [PHRAppDelegate hideLoading];
      // Add new profile
      if (response && response[KEY_Content] != [NSNull null]) {
        ProfileBaby *newBaby = [[ProfileBaby alloc] initWithDictionary:response[KEY_Content]];
        [PHRAppStatus addNewBabyProfile:newBaby];
      }
      [self.navigationController popViewControllerAnimated:YES];
    }error:^(NSString *error){
      [PHRAppDelegate hideLoading];
      [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
    }];
  }
}

#pragma mark - Action sheet date picker delegate
// Action sheet date picker delegate
- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectDate:(NSDate*)date{
  if (self.textFieldBirthday && date) {
    [self.textFieldBirthday setText:[self updateTime:date]];
  }
  if (_baby) {
    _baby.birthday = date;
  }
  [self.comboboxRelationship onClicked];
}

#pragma mark - Proccess for birthday date

- (NSString*)textBirthdayFromDate:(NSDate*)date{
  NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
  [formatter setDateFormat:PHR_BIRTHDAY_SERVER_FORMAT];
  NSCalendar *calendar = [NSCalendar calendarWithIdentifier:NSCalendarIdentifierGregorian];
  [formatter setCalendar:calendar];
  return [formatter stringFromDate:date];
}

- (NSString*)updateTime:(NSDate *)date {
  if (!date) {
    return @"";
  }
  return [UIUtils stringDate:date withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
  
}

- (NSDate*)dateFromBirthdayField{
  if (self.textFieldBirthday) {
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    NSCalendar *calendar = [NSCalendar calendarWithIdentifier:NSCalendarIdentifierGregorian];
    [formatter setCalendar:calendar];
    return [formatter dateFromString:self.textFieldBirthday.text];
  }
  return nil;
}

- (void)didSelectItem {
  [self.textFieldHeight becomeFirstResponder];
}

@end
