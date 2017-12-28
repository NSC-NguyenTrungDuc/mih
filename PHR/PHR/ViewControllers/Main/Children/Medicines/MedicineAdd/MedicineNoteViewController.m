//
//  MedicineNoteViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 10/5/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#define TAG_ALERT_SAVE          1

#import "MedicineNoteViewController.h"
#import <AssetsLibrary/AssetsLibrary.h>
#import "IQActionSheetPickerView.h"
#import "MedicineNote.h"
#import "NSString+Extension.h"

@interface MedicineNoteViewController () <IQActionSheetPickerViewDelegate, UIAlertViewDelegate, PHRViewUploadFileDelegate, UIImagePickerControllerDelegate, UINavigationControllerDelegate>{
    NSMutableArray *listFileName;
    NSMutableArray *_listImgMedicine;
    NSMutableArray *_listImgURL;
    NSMutableArray *_listImgName;
    
    NSArray *_listMethod;
    NSMutableArray *_listButton;
    PHR_ICON_MEDICINE methodMedicine;
    NSString *_preURL;
    
    int _numberImg;
    int _numberImgUpload;
    BabyMedicineModel *_currentModel;
}

@property (assign, nonatomic) BOOL isEditMode;

@end

@implementation MedicineNoteViewController {
    
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    listFileName = [[NSMutableArray alloc] init];
    _listButton = [NSMutableArray new];
    _listImgMedicine = [NSMutableArray new];
    _listImgURL = [NSMutableArray new];
    _listImgName = [NSMutableArray new];
    
    _listMethod = @[@"Icon_Medicine", @"Icon_Medicine_2",
                    @"Icon_Medicine_3", @"Icon_Medicine_4",
                    @"Icon_Medicine_5", @"Icon_Medicine_6",
                    @"Icon_Medicine_7", @"Icon_Medicine_1_Active",
                    @"Icon_Medicine_2_Active", @"Icon_Medicine_3_Active",
                    @"Icon_Medicine_4_Active", @"Icon_Medicine_5_Active",
                    @"Icon_Medicine_6_Active", @"Icon_Medicine_7_Active",];
    
    [self initializeMedicineNoteView];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setBackground];
}

- (void)setBackground{
    if (self.type == PHRGroupTypeStandard) {
        [self setImageToBackgroundStandard:self.mainBackground];
    } else {
        [self setImageToBackgroundBaby:self.mainBackground];
    }
}

- (void)setId_medicine:(NSString *)id_medicine {
    _id_medicine = id_medicine;
    if (id_medicine && ![id_medicine isEmpty]) {
        _isEditMode = YES;
    }
}

#pragma mark - First Run Intialize

- (void)initializeMedicineNoteView {
    [self addButtonMethodInScroolView];
    [self.txtNameMedicine setDelegate:self];
    [self.txtQuantity setDelegate:self];
    [self.txtDose setDelegate:self];
    
    [self.txtNameMedicine setTextColor:PHR_COLOR_GRAY];
    [self.txtQuantity setTextColor:PHR_COLOR_GRAY];
    [self.txtDose setTextColor:PHR_COLOR_GRAY];
    
    [self.txtNameMedicine setPlaceholder:kLocalizedString(kName)];
    [self.txtQuantity setPlaceholder:kLocalizedString(kTitleMedicineQuantity)];
    [self.txtDose setPlaceholder:kLocalizedString(kTitleMedicineDose)];
    
    [self.lbTextPrescription setStyleRegularToLabelWithSize:11.0];
    [self.lbTextPrescription setText:kLocalizedString(kTitlePreUp)];
    
    self.noteMedicine.delegate = self;
    self.noteMedicine.text = kLocalizedString(kNote);
    self.noteMedicine.textColor = [UIColor lightGrayColor];
    
    if (self.type == PHRGroupTypeStandard) {
        [self setupNavigationBarTitle:kLocalizedString(kTitleMedicine) titleIcon:@"Medicine Note" rightItem:[self itemRightStandardKey:kSave]];
        //[self setImageToBackgroundStandard:self.mainBackground];
    } else {
        //[self setImageToBackgroundBaby:self.mainBackground];
        [self setupNavigationBarTitle:kLocalizedString(kTitleMedicine) titleIcon:@"Medicine Note" rightItem:[self itemRightBabyKey:kSave]];
    }
    
    [self.viewMedicineUploadFile setDelegate:self];
    
    // Add Unit Choice list
    [self setSelectedImageToButton:methodMedicine];
    [self.btnUnit setArrayChoices:[MedicineNote arrayUnits]];
    
    [self.btnUploadFile setTitle:kLocalizedString(kUploadFile) forState:UIControlStateNormal];
    [self.btnUploadFile.titleLabel setFont:[FontUtils aileronRegularWithSize:14.0]];
    //[PHRAppDelegate showLoading];
    if (self.isEditMode && self.id_medicine && ![self.id_medicine isEmpty]) {
        __weak __typeof__(self) weakSelf = self;
        
        if (weakSelf.type == PHRGroupTypeBaby) {
            [[PHRClient instance] requestGetDetail:PHRAppStatus.currentBaby.profileId and:self.id_medicine andMethod:API_StandardGetMedicine completion:^(MFRession *responseObject) {
                if (responseObject) {
                    //[PHRAppDelegate hideLoading];
			                 _currentModel = [[BabyMedicineModel alloc] initWithDictionary:responseObject.content error:nil];
			                 [weakSelf fillDataInView:_currentModel];
			                 
                }
                else {
			                 [NSUtils showMessage:APP_NAME withTitle:kLocalizedString(kErrorConectToHost)];
                }
            }];
        }
        else {
            [[PHRClient instance] requestGetDetail:PHRAppStatus.currentStandard.profileId and:self.id_medicine andMethod:API_StandardGetMedicine completion:^(MFRession *responseObject) {
                //[PHRAppDelegate hideLoading];
                if (responseObject) {
			                 _currentModel = [[BabyMedicineModel alloc] initWithDictionary:responseObject.content error:nil];
			                 [weakSelf fillDataInView:_currentModel];
                }
                else {
			                 [NSUtils showMessage:APP_NAME withTitle:kLocalizedString(kErrorConectToHost)];
                }
            }];
        }
    }
    else {
        [self.dateTimeView updateTime:[NSDate date]];
    }
}

- (void)fillDataInView:(BabyMedicineModel *)resultMedicines {
    self.txtNameMedicine.text   = [NSString stringWithFormat:@"%@",resultMedicines.name];
    self.txtDose.text           = [NSString stringWithFormat:@"%@",resultMedicines.dose];
    self.txtQuantity.text       = [NSString stringWithFormat:@"%@",resultMedicines.quantity];
    self.noteMedicine.text      = [NSString stringWithFormat:@"%@",resultMedicines.note];
    
    NSString *date = resultMedicines.time_take_medicine;
    [self.dateTimeView updateTime:[UIUtils dateFromServerTimeString:date]];
    [self.btnUnit setText:resultMedicines.unit];
    
    methodMedicine = [resultMedicines.method intValue];
    _preURL = resultMedicines.prescription_url;
    if (![_preURL isEmpty]) {
        NSArray *arrayURL = [_preURL componentsSeparatedByString:PHR_STR_DETACHMENT];
        _listImgURL = [NSMutableArray arrayWithArray:arrayURL];
        
        for (NSString *strURL in _listImgURL) {
            [listFileName addObject:strURL];
            [_listImgName addObject:[strURL lastPathComponent]];
        }
        
        [self.viewMedicineUploadFile addViewContainFileServerInParentView:_listImgURL];
    }
    [PHRAppDelegate hideLoading];
    [self setSelectedImageToButton:methodMedicine];
}

- (BOOL)isNullOrEmpty:(NSString*)string {
    if (!string) {
        return YES;
    }
    if ([string isEqualToString:PHR_STR_NULL]) {
        return YES;
    }
    return NO;
}

- (void)addButtonMethodInScroolView {
    for (int i = 0; i < 7; i++) {
        UIButton *btn = [UIButton buttonWithType:UIButtonTypeCustom];
        [btn setFrame:CGRectMake(5.0 + 55.0 * i, 5.0, 50.0, 50.0)];
        btn.tag = i;
        
        [btn.layer setBorderColor:[UIColor lightGrayColor].CGColor];
        [btn.layer setBorderWidth:0.5];
        [btn.layer setCornerRadius:2.0];
        
        NSString *img = [_listMethod objectAtIndex:i];
        NSString *imgActive = [_listMethod objectAtIndex:(i + 7)];
        
        [btn setImage:[UIImage imageNamed:img] forState:UIControlStateNormal];
        [btn setImage:[UIImage imageNamed:imgActive] forState:UIControlStateHighlighted];
        [btn setImage:[UIImage imageNamed:imgActive] forState:UIControlStateSelected];
        
        [btn addTarget:self action:@selector(clickMethodButton:) forControlEvents:UIControlEventTouchUpInside];
        
        [_listButton addObject:btn];
        [self.scrollView addSubview:btn];
    }
    
    self.scrollView.showsVerticalScrollIndicator = YES;
    self.scrollView.scrollEnabled = YES;
    self.scrollView.userInteractionEnabled = YES;
    [self.scrollView setContentSize:CGSizeMake(55.0 * 7, 60.0)];
}

- (void)clickMethodButton:(UIButton *)btn {
    [self setSelectedImageToButton:(int)btn.tag];
}

- (void)setSelectedImageToButton:(int)number {
    UIButton *btn = [_listButton objectAtIndex:number];
    NSString *imgActive = [_listMethod objectAtIndex:(number + 7)];
    methodMedicine = number;
    
    [btn setImage:[UIImage imageNamed:imgActive] forState:UIControlStateNormal];
    [btn.layer setBorderColor:PHR_COLOR_ORANGE.CGColor];
    
    for (int i = 0; i < 7; i++) {
        if (i != number) {
            UIButton *currentBtn = [_listButton objectAtIndex:i];
            NSString *img = [_listMethod objectAtIndex:i];
            
            [currentBtn.layer setBorderColor:[UIColor lightGrayColor].CGColor];
            [currentBtn setImage:[UIImage imageNamed:img] forState:UIControlStateNormal];
        }
    }
}

#pragma mark - Override method

- (void)actionNavigationBarItemRight {
    if (self.txtNameMedicine.text.length == 0) {
        [NSUtils showMessage:kLocalizedString(kMedicineNameMiss) withTitle:APP_NAME];
        return;
    }
    if (self.txtQuantity.text.length == 0) {
        [NSUtils showMessage:kLocalizedString(kMedicineQuantityMiss) withTitle:APP_NAME];
        return;
    }
    
    if (!methodMedicine) {
        //
    }
    
    [PHRAppDelegate showLoading];
    
    if (_listImgMedicine.count > 0) {
        [self usingNSOperationQueueToLoadImage:_listImgMedicine];
    }
    else {
        [self createNewMedicineNote];
    }
}

- (void)usingNSOperationQueueToLoadImage:(NSArray*) imageURLs {
    for(UIImage *objImg in _listImgMedicine) {
        [self uploadImageToServerInMedicineView:objImg];
    }
}

- (void)uploadImageToServerInMedicineView:(UIImage*)newImage {
    __weak __typeof(self) weakSelf = self;
    [[NetworkManager sharedManager] processUploadImageInNewThread:newImage andCompletion:^(NSString *msgError, id result) {
        [PHRAppDelegate hideLoading];
        if ([msgError isEqualToString:PHR_STR_NULL]) {
            _numberImg += 1;
            NSString *urlFile = (NSString *)result;
            [_listImgURL addObject:urlFile];
            if (_numberImgUpload == _numberImg) {
                [weakSelf createNewMedicineNote];
            }
        }
    }];
}

- (void)createNewMedicineNote {
    BabyMedicineModel *objNote = [[BabyMedicineModel alloc] init];
    NSString *prescriptionUrl  = PHR_STR_NULL;
    
    if (_listImgURL.count > 0) {
        prescriptionUrl = [_listImgURL firstObject];
        for (int i = 1; i < _listImgURL.count; i++) {
            NSString *str = [_listImgURL objectAtIndex:i];
            NSString *addStr = [NSString stringWithFormat:@"%@%@", PHR_STR_DETACHMENT,str];
            prescriptionUrl  = [prescriptionUrl stringByAppendingString:addStr];
        }
    }
    
    objNote.time_take_medicine  = [self.dateTimeView stringDateParam];
    objNote.name                = self.txtNameMedicine.text;
    objNote.method              = [NSString stringWithFormat:@"%ld", (long)methodMedicine];
    objNote.quantity            = [NSString stringWithFormat:@"%@", self.txtQuantity.text];
    objNote.unit                = [NSString stringWithFormat:@"%@", [self.btnUnit getText]];
    objNote.dose                = [NSString stringWithFormat:@"%@", self.txtDose.text];
    objNote.prescription_url    = prescriptionUrl;
    objNote.note                = [NSString stringWithFormat:@"%@", self.noteMedicine.text];
    
    if (!self.id_medicine || [self.id_medicine isEmpty]) {
        if (self.type == PHRGroupTypeStandard) {
            objNote.id = [NSString stringWithFormat:@"%@", PHRAppStatus.currentStandard.profileId];
        }
        else {
            objNote.id = [NSString stringWithFormat:@"%@", PHRAppStatus.currentBaby.profileId];
        }
        
        [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationAddNewData object:objNote];
        //[self callBackPopView];
        [self saveForMedicineNoteViewWithObj:objNote];
    }
    else {
        NSString *profileID = PHR_STR_NULL;
        if (self.type == PHRGroupTypeStandard) {
            profileID = PHRAppStatus.currentStandard.profileId;
        }
        else {
            profileID = PHRAppStatus.currentBaby.profileId;
        }
        
        NSDictionary *params = @{
                                 KEY_MedicineNote_Time      : objNote.time_take_medicine,
                                 KEY_MedicineNote_Name      : objNote.name,
                                 KEY_MedicineNote_Method    : objNote.method,
                                 KEY_MedicineNote_Quantity  : objNote.quantity,
                                 KEY_MedicineNote_Unit      : objNote.unit,
                                 KEY_MedicineNote_Pre_URL   : objNote.prescription_url,
                                 KEY_MedicineNote_Dose      : objNote.dose,
                                 KEY_Note                   : objNote.note
                                 };
        [[PHRClient instance]requestUpdateData:API_MedicineNote andProdileId:profileID
                                   andObjectId:_currentModel.id withParam:params completion:^(MFRession *result) {
                                       [PHRAppDelegate hideLoading];
                                       if (result) {
                                           objNote.id = _currentModel.id;
                                           self.addMedicineNoteCallBack(objNote);
                                           [self callBackPopView];
                                       }
                                       else {
                                           [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                                       }
                                   }];
    }
}

- (void)saveForMedicineNoteViewWithObj:(BabyMedicineModel *)objNote {
    dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0), ^{
        [[PHRClient instance] requestAddNewMedicineWithObjNote:objNote andCompleted:^(id result) {
            [PHRAppDelegate hideLoading];
            NSDictionary *dict = [[NSDictionary dictionaryWithDictionary:result] valueForKey:KEY_Content];
            BabyMedicineModel *babyMedicineModel = [[BabyMedicineModel alloc] initWithDictionary:dict error:nil];
            if (babyMedicineModel) {
                self.addMedicineNoteCallBack(babyMedicineModel);
            }
            [self callBackPopView];
        } error:^(NSString *error) {
            [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
        }];
    });
}

- (void)callBackPopView {
    [self.navigationController popViewControllerAnimated:YES];
}

#pragma mark - Alert Delegate

- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex {
    if (alertView.tag == TAG_ALERT_SAVE) {
        [self.navigationController popViewControllerAnimated:YES];
    }
}

#pragma mark - UITextField Delegate

- (BOOL)textFieldShouldReturn:(UITextField *)textField {
    [textField resignFirstResponder];
    return YES;
}

#pragma mark - UITextView Delegate

- (void)textViewDidBeginEditing:(UITextView *)textView {
    [self animateTextView:YES];
    if ([textView.text isEqualToString:kLocalizedString(kNote)]) {
        textView.text = @"";
        textView.textColor = PHR_COLOR_GRAY;
    }
    [textView becomeFirstResponder];
}

- (void)textViewDidEndEditing:(UITextView *)textView {
    [self animateTextView:NO];
    if ([textView.text isEqualToString:@""]) {
        textView.text = kLocalizedString(kNote);
        textView.textColor = [UIColor lightGrayColor];
    }
    [textView resignFirstResponder];
}

- (void)animateTextView:(BOOL) up {
    const int movementDistance = 150.0;
    const float movementDuration = 0.3f;
    int movement= movement = (up ? -movementDistance : movementDistance);
    
    [UIView beginAnimations: @"anim" context: nil];
    [UIView setAnimationBeginsFromCurrentState: YES];
    [UIView setAnimationDuration: movementDuration];
    self.view.frame = CGRectOffset(self.view.frame, 0, movement);
    [UIView commitAnimations];
}

#pragma mark - Get File Of Device

- (IBAction)pressBtnUploadFile:(id)sender {
    if ((PHR_FILE_UPLOAD_MAX - _listImgName.count) == 0) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
        return;
    }
    
    if (listFileName.count < PHR_FILE_UPLOAD_MAX) {
#if 0
        UzysAppearanceConfig *appearanceConfig = [[UzysAppearanceConfig alloc] init];
        appearanceConfig.finishSelectionButtonColor = [UIColor blueColor];
        appearanceConfig.assetsGroupSelectedImageName = @"checker.png";
        appearanceConfig.cellSpacing = 1.0f;
        appearanceConfig.assetsCountInALine = 5;
        [UzysAssetsPickerController setUpAppearanceConfig:appearanceConfig];
#endif
        UzysAssetsPickerController *picker = [[UzysAssetsPickerController alloc] init];
        picker.delegate = self;
        
        picker.maximumNumberOfSelectionVideo = 0;
        picker.maximumNumberOfSelectionPhoto = PHR_FILE_UPLOAD_MAX - _listImgName.count;
        
        [self presentViewController:picker animated:YES completion:^{
            //
        }];
    }
}

- (void)imagePickerController:(UIImagePickerController *)picker didFinishPickingMediaWithInfo:(NSDictionary *)info {
    UIImage *chosenImage = info[UIImagePickerControllerEditedImage];
    
    [_listImgMedicine addObject:chosenImage];
    _numberImgUpload += 1;
    
    if (listFileName.count > 0) {
        [self.viewMedicineUploadFile addViewNameFileUploadInParentView:listFileName andListFileName:_listImgName];
    }
    
    [picker dismissViewControllerAnimated:YES completion:NULL];
    
}
#pragma mark - UzysAssetsPickerControllerDelegate Methods

- (void)uzysAssetsPickerController:(UzysAssetsPickerController *)picker didFinishPickingAssets:(NSArray *)assets {
    for (ALAsset *objAlasset in assets) {
        NSURL *originalFileName = [[objAlasset defaultRepresentation] url];
        [listFileName addObject:originalFileName];
        
        NSString *nameFile = [[objAlasset defaultRepresentation] filename];
        [_listImgName addObject:nameFile];
        
        ALAssetsLibrary *library = [[ALAssetsLibrary alloc] init];
        [library assetForURL:originalFileName resultBlock:^(ALAsset *asset) {
            UIImage  *copyOfOriginalImage = [UIImage imageWithCGImage:[[asset defaultRepresentation] fullScreenImage] scale:0.5 orientation:UIImageOrientationUp];
            [_listImgMedicine addObject:copyOfOriginalImage];
            _numberImgUpload += 1;
            [copyOfOriginalImage setAccessibilityIdentifier:[NSString stringWithFormat:@"%@", originalFileName]];
        }
                failureBlock:^(NSError *error) {
                    // error handling
                    NSLog(@"failure-----");
                }];
    }
    
    if (listFileName.count > 0) {
        [self.viewMedicineUploadFile addViewNameFileUploadInParentView:listFileName andListFileName:_listImgName];
    }
}

- (void)uzysAssetsPickerControllerDidExceedMaximumNumberOfSelection:(UzysAssetsPickerController *)picker {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
}

#pragma mark - PHR IMAGE DELEGATE

- (void)deleteFileUpload:(UIButton *)btn {
    if (_numberImgUpload > 0) {
        _numberImgUpload -= 1;
    }
    if (_listImgName.count > 0) {
        [_listImgName removeObjectAtIndex:btn.tag];
    }
    if (listFileName.count > 0) {
        [listFileName removeObjectAtIndex:btn.tag];
    }
    
    if (self.id_medicine && ![self.id_medicine isEmpty]) {
        if (_listImgURL.count > btn.tag) {
            [_listImgURL removeObjectAtIndex:btn.tag];
        }
        else {
            [_listImgMedicine removeObjectAtIndex:(btn.tag - _listImgURL.count)];
        }
    }
    else {
        if (_listImgMedicine.count > 0) {
            [_listImgMedicine removeObjectAtIndex:btn.tag];
        }
    }
}

@end
