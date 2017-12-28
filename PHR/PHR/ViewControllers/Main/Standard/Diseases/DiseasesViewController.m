//
//  DiseasesViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 10/4/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "DiseasesViewController.h"

@interface DiseasesViewController () <UzysAssetsPickerControllerDelegate, UITextViewDelegate, UIAlertViewDelegate, PHRViewUploadFileDelegate> {
    NSMutableArray *listFileName;
    NSMutableArray *_arrayUploadImage;
    NSMutableArray *_listImgURL;
    NSMutableArray *_listImgName;
    int _numberIMG, _maxImage;
    NSString *_preURL;
}

@end

@implementation DiseasesViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setupNavigationBarTitle:kLocalizedString(kTitleDiseases) titleIcon:@"icon_title_injuries" rightItem:nil /*kLocalizedString(kSave)*/];
    [self initializeView];
}

- (void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    [self setImageToBackgroundStandard:self.backgroundImage];
}
- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)initializeView {
    // note
    self.noteDiseasesVC.delegate  = self;
    self.noteDiseasesVC.text      = kLocalizedString(kNote);
    self.noteDiseasesVC.textColor = [UIColor lightGrayColor];
    
    [self.lbtextEvidence setText:kLocalizedString(kTitleUpload)];
    [self.btnUploadFile setTitle:kLocalizedString(kUploadFile) forState:UIControlStateNormal];
    [self.btnUploadFile.titleLabel setFont:[FontUtils aileronRegularWithSize:14.0]];
    
    listFileName = [[NSMutableArray alloc] init];
    _arrayUploadImage = [[NSMutableArray alloc] init];
    _listImgURL = [[NSMutableArray alloc] init];
    _listImgName = [NSMutableArray new];
    
    [self.txtStatus setPlaceholder:kLocalizedString(kStatus)];
    [self.txtHospital setPlaceholder:kLocalizedString(kHospital)];
    [self.viewUploadFileDiseases setDelegate:self];
    
    self.labelTitleHospital.font = [FontUtils aileronRegularWithSize:10];
    self.labelDiseasesName.font = [FontUtils aileronRegularWithSize:10];
    self.labelOutCome.font = [FontUtils aileronRegularWithSize:10];
    
    self.labelTitleHospital.text = kLocalizedString(kHospitalnameUpperCase);
    self.labelDiseasesName.text = kLocalizedString(kDiseasesName);
    self.labelOutCome.text = kLocalizedString(kOutCome);
    
    [self.txtHospital setEnabled:NO];
    [self.txtStatus setEnabled:NO];
    [self.textOutCome setEnabled:NO];
    
    // Datetime
    [self.dateTimeRecord setClickEnable:NO];
    [self.dateTimeDiseasesBegin setClickEnable:NO];
    [self.dateTimeDiseasesEnd setClickEnable:NO];
    self.dateTimeDiseasesBegin.titleContent = kLocalizedString(kStartDate);
    self.dateTimeDiseasesEnd.titleContent = kLocalizedString(kEndDate);
    
    if (self.model) {
        [self fillDataDiseasesToScreen:_model];
    }
}

- (void)fillDataDiseasesToScreen:(DiseasesModel *)model {
    [self.txtStatus setText:model.disease_name];
    [self.txtHospital setText:model.hospital];
    [self.dateTimeRecord updateTimeFromString:model.datetime_record];
    
    if ([[UIUtils dateFromServerTimeString:model.start_date] isKindOfClass:[NSDate class]]) {
        [self.dateTimeDiseasesBegin updateTime:[UIUtils dateFromServerTimeString:model.start_date] shortFormat:YES];
    } else if (!([[UIUtils dateFromServerTimeString:model.start_date] isKindOfClass:[NSDate class]]))  {
        NSDate *date = [UIUtils dateFromString:model.start_date withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
        [self.dateTimeDiseasesBegin updateTime:date shortFormat:YES];
    } else {
        [self.dateTimeDiseasesBegin updateTime:nil];
    }
    
    if ([[UIUtils dateFromServerTimeString:model.end_date] isKindOfClass:[NSDate class]]) {
        [self.dateTimeDiseasesEnd updateTime:[UIUtils dateFromServerTimeString:model.end_date] shortFormat:YES];
    } else if (!([[UIUtils dateFromServerTimeString:model.end_date] isKindOfClass:[NSDate class]])) {
        NSDate *date = [UIUtils dateFromString:model.end_date withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
        [self.dateTimeDiseasesEnd updateTime:date shortFormat:YES];
    } else {
        [self.dateTimeDiseasesEnd updateTime:nil];
    }
    
    [self.textOutCome setText:model.outcome];
    
    //_preURL = model.medical_record_url;
//    if (![_preURL isEmpty]) {
//        NSArray *arrayURL = [_preURL componentsSeparatedByString:PHR_STR_DETACHMENT];
//        _listImgURL = [NSMutableArray arrayWithArray:arrayURL];
//        
//        for (NSString *strURL in _listImgURL) {
//            [listFileName addObject:strURL];
//            [_listImgName addObject:[strURL lastPathComponent]];
//        }
//        
//        [self.viewUploadFileDiseases addViewContainFileServerInParentView:_listImgURL];
//    }
//    [PHRAppDelegate hideLoading];
}

#pragma mark - Navigation

- (void)actionNavigationBarItemRight {
//    if ([UIUtils isNullOrEmpty:self.txtHospital.text]) {
//        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kHospitalNul)];
//        return;
//    }
//    
//    [PHRAppDelegate showLoading];
//    if (_arrayUploadImage.count > 0) {
//        [self usingNSOperationQueueToLoadImage:_arrayUploadImage];
//    }
//    else {
//        [self addNewDiseases];
//    }
  [self.navigationController popViewControllerAnimated:YES];
}

- (void)addNewDiseases {
    DiseasesModel *objDiseases = [[DiseasesModel alloc] init];
    if (_listImgURL.count > 0) {
        _preURL = [_listImgURL firstObject];
        for (int i = 1; i < _listImgURL.count; i++) {
            NSString *str = [_listImgURL objectAtIndex:i];
            _preURL = [_preURL stringByAppendingString:[NSString stringWithFormat:@"%@%@",PHR_STR_DETACHMENT, str]];
        }
    }
    else {
        _preURL = PHR_STR_NULL;
    }
    
    objDiseases.datetime_record     = [self.dateTimeDiseasesBegin stringDateParam];
    objDiseases.hospital            = self.txtHospital.text;
    objDiseases.disease_name              = self.txtStatus.text;
//    objDiseases.note                = self.noteDiseasesVC.text;
//    objDiseases.medical_record_url  = _preURL;
    
    __weak __typeof(self) weakSelf = self;
    if (self.id_diseases && ![self.id_diseases isEmpty]) {
        objDiseases.disease_id = self.id_diseases;
        NSDictionary *params = @{
                                 KEY_DateRecord                 : objDiseases.datetime_record,
                                 KEY_ProgressCourse_Hospital    : objDiseases.hospital,
                                 KEY_ProgressCourse_Status      : objDiseases.disease_name,
//                                 KEY_ProgressCourse_Record_Url  : objDiseases.medical_record_url,
//                                 KEY_Note                       : objDiseases.note,
                                 };
        
        [[PHRClient instance] requestUpdateData:API_StandardDiseases andProdileId:PHRAppStatus.currentStandard.profileId
                                    andObjectId:self.id_diseases withParam:params completion:^(MFRession *response) {
                                        [PHRAppDelegate hideLoading];
                                        if (response) {
                                            self.addDiseasesCallBack(objDiseases);
                                            [weakSelf.navigationController popViewControllerAnimated:YES];
                                        }
                                        else {
                                            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                                        }
                                    }];
    }
    else {
        [[PHRClient instance] requestAddNewDiseases:objDiseases completed:^(id result) {
            [PHRAppDelegate hideLoading];
            NSDictionary *dict = [[NSDictionary dictionaryWithDictionary:result] valueForKey:KEY_Content];
            DiseasesModel *modelDiseases = [[DiseasesModel alloc] initWithDictionary:dict error:nil];
            if (modelDiseases) {
                self.addDiseasesCallBack(modelDiseases);
            }
            [weakSelf.navigationController popViewControllerAnimated:YES];
        } error:^(NSString *error) {
            [PHRAppDelegate hideLoading];
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
        }];
    }
}

- (IBAction)pressBtnUploadFile:(id)sender {
    if ((PHR_FILE_UPLOAD_MAX - _maxImage) == 0) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
        return;
    }
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
    
    picker.maximumNumberOfSelectionVideo = 0.0;
    picker.maximumNumberOfSelectionPhoto = PHR_FILE_UPLOAD_MAX - _maxImage;
    
    [self presentViewController:picker animated:YES completion:^{
        //
    }];
}

#pragma mark - Upload Image

- (void)usingNSOperationQueueToLoadImage:(NSArray*) imageURLs {
    for(UIImage *objImg in _arrayUploadImage) {
        [self uploadImageToServerInMedicineView:objImg];
    }
}

- (void)uploadImageToServerInMedicineView:(UIImage*)newImage {
    __weak __typeof(self) weakSelf = self;
    [[NetworkManager sharedManager] processUploadImageInNewThread:newImage andCompletion:^(NSString *msgError, id result) {
        if ([msgError isEqualToString:PHR_STR_NULL]) {
            _numberIMG += 1;
            NSString *urlFile = (NSString *)result;
            [_listImgURL addObject:urlFile];
            if (_maxImage == _numberIMG) {
                [weakSelf addNewDiseases];
            }
        }
    }];
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
            [_arrayUploadImage addObject:copyOfOriginalImage];
            _maxImage += 1;
            [copyOfOriginalImage setAccessibilityIdentifier:[NSString stringWithFormat:@"%@", originalFileName]];
        }
                failureBlock:^(NSError *error) {
                    NSLog(@"failure-----");
                }];
    }
    
    if (listFileName.count > 0) {
        [self.viewUploadFileDiseases addViewNameFileUploadInParentView:listFileName andListFileName:_listImgName];
    }
}

- (void)uzysAssetsPickerControllerDidExceedMaximumNumberOfSelection:(UzysAssetsPickerController *)picker {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
}

- (void)deleteFileUpload:(UIButton *)btn {
    if (_maxImage > 0) {
        _maxImage -= 1;
    }
    if (_listImgName.count > 0) {
        [_listImgName removeObjectAtIndex:btn.tag];
    }
    if (listFileName.count > 0) {
        [listFileName removeObjectAtIndex:btn.tag];
    }
    if (_listImgURL.count > 0) {
        [_listImgURL removeObjectAtIndex:btn.tag];
    }
    if (_arrayUploadImage.count > 0) {
        [_arrayUploadImage removeObjectAtIndex:btn.tag];
    }
    //    if (_arrayUploadImage.count == 0) {
    //        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTitleDeleteImage)];
    //    }
}

#pragma mark - UITextView Delegate

- (void)textViewDidBeginEditing:(UITextView *)textView {
    [self animateTextView:YES];
    if ([textView.text isEqualToString:kLocalizedString(kNote)]) {
        textView.text = PHR_STR_NULL;
        textView.textColor = PHR_COLOR_GRAY;
    }
    [textView becomeFirstResponder];
}

- (void)textViewDidEndEditing:(UITextView *)textView {
    [self animateTextView:NO];
    if ([textView.text isEqualToString:PHR_STR_NULL]) {
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

@end
