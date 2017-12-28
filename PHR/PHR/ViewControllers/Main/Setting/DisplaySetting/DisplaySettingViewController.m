//
//  DisplaySettingViewController.m
//  PHR
//
//  Created by SonNV1368 on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "DisplaySettingViewController.h"
#import "DisplaySettingCollectionViewCell.h"

#import "BackgroundSettingInfo.h"
#import "LocalStorageImage.h"
#import <PureLayout/PureLayout.h>

#define PHR_TAG_IMAGE    1000

@interface DisplaySettingViewController ()
@end

@implementation DisplaySettingViewController {
    NSMutableArray *arrayImageChooseBackground;
    NSMutableArray *arrayImageAddYourBackground;
    int indexSelected;
    int indexSelectedUpload;
    NSString *_url_BG_Image;
    NSString *strBGLocal;
    BOOL _isShowAlert;
    BackgroundSettingInfo *_backgroundInfo;
    NSMutableArray *arrayLocalStorageImage;
    BOOL _isLocalSelected;
    BOOL isStorageStandard;
    BOOL isStorageBaby;
    int standardSelectedIndex;
    int babySelectedIndex;
    LocalStorageImage *imageToLocalStorage;
    NSIndexPath *indexPathOpen;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initDisplaySettingView];
    [self setupUI];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    //    indexPathOpen = [NSIndexPath indexPathForItem:0 inSection:0];
    //    [self collectionView:self.collectChooseBackground didSelectItemAtIndexPath:indexPathOpen];
    //[self setImageToBackgroundStandard:self.BG_MainDisplay];
    [self setSelectedForCollectionView];
    [self setImageToBackground:self.BG_MainDisplay];
}

#pragma mark - Public Methods
- (void) setupUI {
    indexSelected = indexSelectedUpload = PHR_TAG_IMAGE;
    
    [self setupNavigationBarTitle:kLocalizedString(kTitleDisplaySetting) titleIcon:@"Icon_Image_White" rightItem:kLocalizedString(kSave)];
    
    arrayImageChooseBackground = [NSMutableArray arrayWithObjects:BG_Standard_Medicine, @"BGHome", BG_Baby_Medicine, BG_Standard_Medicine, nil];
    arrayImageAddYourBackground = [[NSMutableArray alloc] init];
    
    arrayLocalStorageImage = [[NSMutableArray alloc]init];
    
    if (PHRAppStatus.backgroundImageList.count > 0){
        for (LocalStorageImage *obj in PHRAppStatus.backgroundImageList){
            [arrayImageAddYourBackground addObject:[UIImage imageWithData:obj.imageData]];
            [arrayLocalStorageImage addObject:obj];
        }
    }
    
    // Register cell
    [self.collectChooseBackground registerNib:[UINib nibWithNibName:NSStringFromClass([DisplaySettingCollectionViewCell class]) bundle:nil]
                   forCellWithReuseIdentifier:NSStringFromClass([DisplaySettingCollectionViewCell class])];
    
    [self.collectAddYourBackground registerNib:[UINib nibWithNibName:NSStringFromClass([DisplaySettingCollectionViewCell class]) bundle:nil]
                    forCellWithReuseIdentifier:NSStringFromClass([DisplaySettingCollectionViewCell class])];
}

- (void)setSelectedForCollectionView{
    if (!PHRAppStatus.back) {
        if (PHRAppStatus.type == PHRGroupTypeStandard) {
            indexPathOpen = [NSIndexPath indexPathForItem:[arrayImageChooseBackground indexOfObject:BG_Standard_Medicine] inSection:0];
            
        } else if (PHRAppStatus.type == PHRGroupTypeBaby){
            indexPathOpen = [NSIndexPath indexPathForItem:[arrayImageChooseBackground indexOfObject:BG_Baby_Medicine] inSection:0];
        }
        [self collectionView:self.collectChooseBackground didSelectItemAtIndexPath:indexPathOpen];
    } else if (PHRAppStatus.back) {
        
        if (PHRAppStatus.type == PHRGroupTypeStandard){
            indexPathOpen = [NSIndexPath indexPathForItem:PHRAppStatus.back.standardImageSelectedIndex inSection:0];
            if (PHRAppStatus.back.isStorageStandard == NO) {
                [self collectionView:self.collectChooseBackground didSelectItemAtIndexPath:indexPathOpen];
            } else if (arrayImageAddYourBackground.count > 1) {
                [self collectionView:self.collectAddYourBackground didSelectItemAtIndexPath:indexPathOpen];
            }
        } else if (PHRAppStatus.type == PHRGroupTypeBaby){
            
            indexPathOpen = [NSIndexPath indexPathForItem:PHRAppStatus.back.babyImageSelectedIndex inSection:0];
            if (PHRAppStatus.back.isStorageBaby == NO) {
                [self collectionView:self.collectChooseBackground didSelectItemAtIndexPath:indexPathOpen];
            } else if (arrayImageAddYourBackground.count > 1){
                [self collectionView:self.collectAddYourBackground didSelectItemAtIndexPath:indexPathOpen];
            }
        }
    }
}

- (void)initDisplaySettingView {
    self.viewAccordion = [[AccordionView alloc] initWithFrame:CGRectMake(0, 0, SCREEN_WIDTH, SCREEN_HEIGHT)];
    self.viewAccordion.delegate = self;
    
    _isLocalSelected = NO;
    isStorageStandard = NO;
    isStorageBaby = NO;
    standardSelectedIndex = 0;
    babySelectedIndex = 0;
    
    [self.viewContent addSubview:self.viewAccordion];
    [self.viewAccordion autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [self.viewAccordion autoPinEdgeToSuperviewEdge:ALEdgeTop];
    [self.viewAccordion autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [self.viewAccordion autoPinEdgeToSuperviewEdge:ALEdgeBottom];
    [self.viewAccordion setAllowsMultipleSelection:YES];
    [self.viewAccordion setAllowsEmptySelection:YES];
    
    
    //choose background
    UIButton *header1 = [self createButtonHeaderWithTitle:kLocalizedString(kTitleChooseBackgrounds)];
    [self.viewAccordion addHeader:header1 withView:self.viewChooseBackground];
    
    //add your background
    UIButton *header2 = [self createButtonHeaderWithTitle:kLocalizedString(kTitleAddYourBackgrounds)];
    [self.viewAccordion addHeader:header2 withView:self.viewAddYourBackground];
}

- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {
    static NSString *identifier = @"DisplaySettingCollectionViewCell";
    
    DisplaySettingCollectionViewCell *cell = (DisplaySettingCollectionViewCell *)[collectionView dequeueReusableCellWithReuseIdentifier:identifier forIndexPath:indexPath];
    
    if (cell == nil) {
        NSArray *nib = [[NSBundle mainBundle] loadNibNamed:@"DisplaySettingCollectionViewCell" owner:self options:nil];
        cell = [nib objectAtIndex:0];
    }
    
    int index = (int)indexPath.row;
    
    if(collectionView == self.collectChooseBackground) {
        cell.imageBackground.image = [UIImage imageNamed:[arrayImageChooseBackground objectAtIndex:indexPath.row]];
        
        if (indexSelected == index) {
            [cell.buttonPreview setBackgroundColor:PHR_COLOR_BACKGROUND_CHOOSE];
            [cell.buttonPreview setImage:[UIImage imageNamed:@"Icon_Check"] forState:UIControlStateNormal];
            [cell.buttonPreview setTitle:kLocalizedString(kLabelSelected) forState:UIControlStateNormal];
            [cell.buttonPreview setAlpha:1.0f];
        }else{
            [cell.buttonPreview setBackgroundColor:[UIColor blackColor]];
            [cell.buttonPreview setImage:nil forState:UIControlStateNormal];
            [cell.buttonPreview setTitle:kLocalizedString(kLabelPreview) forState:UIControlStateNormal];
            [cell.buttonPreview setAlpha:0.6f];
        }
    }
    else {
        if (index < [arrayImageAddYourBackground count]) {
            cell.imageBackground.image = [arrayImageAddYourBackground objectAtIndex:(index)];
            
            [cell.buttonPreview setImage:nil forState:UIControlStateNormal];
            [cell.buttonPreview setTitle:kLocalizedString(kLabelRecentUpload) forState:UIControlStateNormal];
            [cell.buttonPreview setHidden:NO];
            [cell.buttonPreview setAlpha:0.6f];
            [cell.buttonPreview setBackgroundColor:[UIColor blackColor]];
            
            cell.viewCell.layer.borderColor = PHR_COLOR_GRAY.CGColor;
            cell.viewCell.layer.borderWidth = 0;
            
        }else{
            if ([NSUtils checkJPLanguage]) {
                cell.imageBackground.image = [UIImage imageNamed:@"uploadImageJapanese"];
            } else {
                cell.imageBackground.image = [UIImage imageNamed:@"Upload_Image"];
            }
            [cell.buttonPreview setImage:nil forState:UIControlStateNormal];
            [cell.buttonPreview setTitle:kLocalizedString(kUploadImage) forState:UIControlStateNormal];
            [cell.buttonPreview setHidden:YES];
            
            cell.viewCell.layer.borderColor = PHR_COLOR_GRAY.CGColor;
            cell.viewCell.layer.borderWidth = 1;
            [cell.buttonPreview setAlpha:0.6f];
        }
        if (indexSelectedUpload == index) {
            [cell.buttonPreview setBackgroundColor:PHR_COLOR_BACKGROUND_CHOOSE];
            [cell.buttonPreview setImage:[UIImage imageNamed:@"Icon_Check"] forState:UIControlStateNormal];
            [cell.buttonPreview setTitle:kLocalizedString(kLabelSelected) forState:UIControlStateNormal];
            [cell.buttonPreview setAlpha:1.0f];
        }
        
    }
    return cell;
}

- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath {
    if (collectionView == self.collectChooseBackground) {
        indexSelected = (int)indexPath.row;
        indexSelectedUpload = PHR_TAG_IMAGE;
        
        strBGLocal = [arrayImageChooseBackground objectAtIndex:indexSelected];
        
        [self.collectAddYourBackground reloadData];
        [self.collectChooseBackground reloadData];
        
        _isLocalSelected  = YES;
        isStorageStandard = NO;
        isStorageBaby     = NO;
        standardSelectedIndex = (int)indexPath.row;
        babySelectedIndex     = (int)indexPath.row;
    }
    else{
        if((int)indexPath.row == ([arrayImageAddYourBackground count])) {
#if 0
            UzysAppearanceConfig *appearanceConfig = [[UzysAppearanceConfig alloc] init];
            appearanceConfig.finishSelectionButtonColor = [UIColor blueColor];
            appearanceConfig.assetsGroupSelectedImageName = @"checker.png";
            appearanceConfig.cellSpacing = 1.0f;
            appearanceConfig.assetsCountInALine = 5;
            [UzysAssetsPickerController setUpAppearanceConfig:appearanceConfig];
#endif
            [NSUtils createPhotoLibrary:self andViewController:self];

        }
        else {
            standardSelectedIndex = (int)indexPath.row;
            babySelectedIndex     = (int)indexPath.row;
            isStorageStandard     = YES;
            isStorageBaby         = YES;
            
            indexSelectedUpload = (int)indexPath.row;
            indexSelected = PHR_TAG_IMAGE;
            
            [self.collectAddYourBackground reloadData];
            [self.collectChooseBackground reloadData];
            
        }
        _isLocalSelected = NO;
    }
}

- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {
    if (collectionView == self.collectChooseBackground) {
        return [arrayImageChooseBackground count];
    }
    else{
        return [arrayImageAddYourBackground count] + 1;
    }
}

- (CGSize)collectionView:(UICollectionView *)collectionView
                  layout:(UICollectionViewLayout*)collectionViewLayout
  sizeForItemAtIndexPath:(NSIndexPath *)indexPath {
    return CGSizeMake((SCREEN_WIDTH - 60)/2, 100);
}

#pragma mark - UzysAssetsPickerControllerDelegate Methods

- (void)assetsPickerController:(CTAssetsPickerController *)picker didFinishPickingAssets:(NSArray *)assets
{
    PHImageRequestOptions *requestOptions = [[PHImageRequestOptions alloc] init];
    requestOptions.resizeMode   = PHImageRequestOptionsResizeModeExact;
    requestOptions.deliveryMode = PHImageRequestOptionsDeliveryModeHighQualityFormat;
    

    PHImageManager *manager = [PHImageManager defaultManager];
    CGFloat scale = UIScreen.mainScreen.scale;
    
    CGSize targetSize = CGSizeMake(150 * scale, 150 * scale);

    __block NSInteger index = 0;
    __block int imamgeNo = 1;
    
    for (PHAsset *objAlasset in assets) {
        __block int countSameImage = 0;
        [manager ctassetsPickerRequestImageForAsset:objAlasset
                                            targetSize:targetSize
                                        contentMode:PHImageContentModeDefault
                                            options:requestOptions
                                        resultHandler:^(UIImage *image, NSDictionary *info){
                                            [arrayImageAddYourBackground addObject:image];
                                            
                                            if (arrayLocalStorageImage.count > 0) {
                                                for (LocalStorageImage* obj in arrayLocalStorageImage){
                                                    if([obj.imageData isEqualToData:UIImageJPEGRepresentation(image,1)]){
                                                        countSameImage ++;
                                                    }
                                                }
                                            }
                                            
                                            if (countSameImage == 0){
                                                imageToLocalStorage = [[LocalStorageImage alloc] init];
                                                imageToLocalStorage.Id = imamgeNo;
                                                imageToLocalStorage.imageData = UIImageJPEGRepresentation(image,1);
                                                imageToLocalStorage.imageName = [NSString stringWithFormat:@"%@",[UIUtils formatDateAnd24TimeStyle:[NSDate new]]];
                                                [arrayLocalStorageImage addObject:imageToLocalStorage];
                                                
                                                // [SAVE] Image List to LOCAL STORAGE
                                                PHRAppStatus.globalRealm = [RLMRealm defaultRealm];
                                                [PHRAppStatus.globalRealm beginWriteTransaction];
                                                LocalStorageImage* obj = (LocalStorageImage*) [arrayLocalStorageImage objectAtIndex:arrayLocalStorageImage.count-1];
                                                [PHRAppStatus.globalRealm addObject:obj];
                                                [PHRAppStatus.globalRealm commitWriteTransaction];
                                                
                                                imamgeNo++;
                                                PHRAppStatus.backgroundImageList = [LocalStorageImage allObjects];
                                                NSLog(@"[LocalStorageImage allObjects]: %@",[LocalStorageImage allObjects]);
                                            } else {
                                                [arrayImageAddYourBackground removeObjectAtIndex:arrayImageAddYourBackground.count - 1];
                                            }
                                            
                                            if (index == assets.count - 1) {
                                                [self updateView];
                                            }
                                            
                                            index++;
                                          }];
        }
    
    [picker dismissViewControllerAnimated:YES completion:nil];
    
}

- (void)updateView{
    indexSelectedUpload = PHR_TAG_IMAGE;
    
    [self.collectAddYourBackground reloadData];
    [self.collectChooseBackground reloadData];
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

//- (void)uzysAssetsPickerController:(UzysAssetsPickerController *)picker didFinishPickingAssets:(NSArray *)assets {
//    BOOL isChanged = NO;
//    int imamgeNo = 1;
//    
//    for (ALAsset *objAlasset in assets) {
//        int countSameImage = 0;
//        UIImage *img = [UIImage imageWithCGImage:objAlasset.defaultRepresentation.fullResolutionImage
//                                           scale:objAlasset.defaultRepresentation.scale
//                                     orientation:(UIImageOrientation)objAlasset.defaultRepresentation.orientation];
//        isChanged = YES;
//        
//        [arrayImageAddYourBackground addObject:img];
//        //        imageUpload = img;
//        //[self processUploadImageInNewThread:img];
//        if (arrayLocalStorageImage.count > 0) {
//            for (LocalStorageImage* obj in arrayLocalStorageImage){
//                if([obj.imageData isEqualToData:UIImageJPEGRepresentation(img,1)]){
//                    countSameImage ++;
//                }
//            }
//        }
//        
//        if (countSameImage == 0){
//            imageToLocalStorage = [[LocalStorageImage alloc] init];
//            imageToLocalStorage.Id = imamgeNo;
//            imageToLocalStorage.imageData = UIImageJPEGRepresentation(img,1);
//            imageToLocalStorage.imageName = [NSString stringWithFormat:@"%@",[UIUtils formatDateAnd24TimeStyle:[NSDate new]]];
//            [arrayLocalStorageImage addObject:imageToLocalStorage];
//            
//            // [SAVE] Image List to LOCAL STORAGE
//            PHRAppStatus.globalRealm = [RLMRealm defaultRealm];
//            [PHRAppStatus.globalRealm beginWriteTransaction];
//            LocalStorageImage* obj = (LocalStorageImage*) [arrayLocalStorageImage objectAtIndex:arrayLocalStorageImage.count-1];
//            [PHRAppStatus.globalRealm addObject:obj];
//            [PHRAppStatus.globalRealm commitWriteTransaction];
//            
//            imamgeNo++;
//            PHRAppStatus.backgroundImageList = [LocalStorageImage allObjects];
//            NSLog(@"[LocalStorageImage allObjects]: %@",[LocalStorageImage allObjects]);
//        } else {
//            [arrayImageAddYourBackground removeObjectAtIndex:arrayImageAddYourBackground.count - 1];
//        }
//    }
//    
//    if (isChanged) {
//        indexSelectedUpload = PHR_TAG_IMAGE;
//        
//        [self.collectAddYourBackground reloadData];
//        [self.collectChooseBackground reloadData];
//        
//        isChanged = NO;
//    }
//}
//
//- (void)uzysAssetsPickerControllerDidExceedMaximumNumberOfSelection:(UzysAssetsPickerController *)picker {
//    [NSUtils showAlertWithTitle:APP_NAME message:NSLocalizedStringFromTable(@"Only choose one file", @"UzysAssetsPickerController", nil)];
//}

#pragma mark - UI Actions

- (IBAction)touchButtonChooseBackground:(id)sender {
    
}

- (IBAction)touchButtonAddYourBackground:(id)sender {
    
}

- (void)processUploadImageInNewThread:(UIImage*)newImage {
    [[PHRClient instance] uploadBackgroundToServer:newImage andCompletion:^(MFResponse *responseObject) {
        if (responseObject == nil) {
            dispatch_async(dispatch_get_main_queue(), ^{
                [PHRAppDelegate hideLoading];
                if (_isShowAlert) {
                    _isShowAlert = NO;
                    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                }
            });
        }
        else {
            _url_BG_Image = [NSString stringWithFormat:@"%@",responseObject.content];
        }
    }];
}
// @quytm add to show popup background setting
- (void)showPopupSetting {
    UIActionSheet *popup = [[UIActionSheet alloc] initWithTitle:nil delegate:self cancelButtonTitle:kLocalizedString(kCancel) destructiveButtonTitle:nil otherButtonTitles: kLocalizedString(kStandardScreen),kLocalizedString(kBabyScreen),kLocalizedString(kBoth),nil];
    popup.tag = 1;
    [popup showInView:self.view];
}

- (void)actionSheet:(UIActionSheet *)popup clickedButtonAtIndex:(NSInteger)buttonIndex {
    
    PHRAppStatus.backgroundResult = [BackgroundSettingInfo allObjects];
    PHRAppStatus.globalRealm = [RLMRealm defaultRealm];
    
    switch (popup.tag) {
        case 1: {
            switch (buttonIndex) {
                case 0:
                   //  [self saveImageToBackGroundStandard:[NSString stringWithFormat:@"%@", strBGLocal] isBaby:NO];
                    PHRAppStatus.isLocalStandard = _isLocalSelected;
                    [self saveSettingForStandard];
                    [self.navigationController popViewControllerAnimated:YES];
                    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBackToDashbroad object:nil];
                    break;
                case 1:
                   // [self saveImageToBackGroundStandard:[NSString stringWithFormat:@"%@", strBGLocal] isBaby:YES];
                    PHRAppStatus.isLocalBaby     = _isLocalSelected;
                    [self saveSettingForBaby];
                    [self.navigationController popViewControllerAnimated:YES];
                    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBackToDashbroad object:nil];
                    break;
                case 2:
                    //[self saveImageToBackGroundStandard:[NSString stringWithFormat:@"%@", strBGLocal] isBaby:NO];
                    // [self saveImageToBackGroundStandard:[NSString stringWithFormat:@"%@", strBGLocal] isBaby:YES];
                    PHRAppStatus.isLocalBaby     = _isLocalSelected;
                    PHRAppStatus.isLocalStandard = _isLocalSelected;
                    [self saveSettingForStandard];
                    [self saveSettingForBaby];
                    [self.navigationController popViewControllerAnimated:YES];
                    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBackToDashbroad object:nil];
                    break;
                default:
                    break;
            }
            break;
        }
        default:
            break;
    }
}

- (void) saveSettingForStandard {
//    [self saveImageToBackGroundStandard:[NSString stringWithFormat:@"%@", strBGLocal]];
    [PHRAppStatus.globalRealm beginWriteTransaction];
    _backgroundInfo = [[PHRAppStatus.backgroundResult objectsWhere:[NSString stringWithFormat:@"userID='%@'", PHRAppStatus.masterProfileId]]lastObject];
    
    if (_backgroundInfo != nil) { // update
        NSLog(@"RLMRealm->[UPDATE]");
        //_backgroundInfo = [PHRAppStatus.backgroundResult lastObject];
        _backgroundInfo.standardImageSelectedIndex = standardSelectedIndex;
        _backgroundInfo.imageNameStandard = strBGLocal;
        _backgroundInfo.isStorageStandard = isStorageStandard;
        
    } else { // add new to local
        NSLog(@"RLMRealm->[INSERT]");
        _backgroundInfo = [[BackgroundSettingInfo alloc]init];
        _backgroundInfo.standardImageSelectedIndex = standardSelectedIndex;
        _backgroundInfo.imageNameStandard = strBGLocal;
        _backgroundInfo.isStorageStandard = isStorageStandard;
        _backgroundInfo.imageNameBaby = BG_Standard_Medicine;
        _backgroundInfo.isStorageBaby          = isStorageBaby;
        _backgroundInfo.userID =  PHRAppStatus.masterProfileId;
        [PHRAppStatus.globalRealm addObject:_backgroundInfo];
    }
    [PHRAppStatus.globalRealm commitWriteTransaction];
//    PHRAppStatus.back = [[BackgroundSettingInfo allObjects] lastObject];
    PHRAppStatus.back = [[BackgroundSettingInfo objectsWhere:[NSString stringWithFormat:@"userID='%@'", PHRAppStatus.masterProfileId]] lastObject];

    //           [[PHRClient instance] requestChangeBackgroundStangard:_url_BG_Image];
    //        PHRAppStatus.standardBackgroundUrl = [NSString stringWithFormat:@"%@", _url_BG_Image];
}

- (void) saveSettingForBaby {
   
    [PHRAppStatus.globalRealm beginWriteTransaction];
    _backgroundInfo = [[PHRAppStatus.backgroundResult objectsWhere:[NSString stringWithFormat:@"userID='%@'", PHRAppStatus.masterProfileId]] lastObject];
//        _backgroundInfo = [[PHRAppStatus.backgroundResult objectsWhere:@"userID='911'"] lastObject];
    if(_backgroundInfo != nil){
        NSLog(@"RLMRealm->[UPDATE]");
        _backgroundInfo.babyImageSelectedIndex = babySelectedIndex;
        _backgroundInfo.imageNameBaby          = strBGLocal;
        _backgroundInfo.isStorageBaby          = isStorageBaby;
        NSLog(@"%@ - %@",_backgroundInfo.imageNameStandard ,_backgroundInfo.imageNameBaby );
        
       // BackgroundSettingInfo _oldBackgroundInfo = [PHRAppStatus.backgroundResult lastObject];
        //
//        _backgroundInfo = [[BackgroundSettingInfo alloc]init];
//        _backgroundInfo.babyImageSelectedIndex = babySelectedIndex;
//        _backgroundInfo.imageNameBaby          = strBGLocal;
//        _backgroundInfo.isStorageBaby          = isStorageBaby;
//        _backgroundInfo.imageNameStandard      = BG_Standard_Medicine;
//        _backgroundInfo.isStorageStandard      = isStorageStandard;
//        [PHRAppStatus.globalRealm addObject:_backgroundInfo];
    } else { // add new to local
        NSLog(@"RLMRealm->[INSERT]");
        _backgroundInfo = [[BackgroundSettingInfo alloc]init];
        _backgroundInfo.babyImageSelectedIndex = babySelectedIndex;
        _backgroundInfo.imageNameBaby          = strBGLocal;
        _backgroundInfo.isStorageBaby          = isStorageBaby;
        _backgroundInfo.imageNameStandard      = BG_Standard_Medicine;
         _backgroundInfo.isStorageStandard      = isStorageStandard;
        _backgroundInfo.userID =  PHRAppStatus.masterProfileId;
        [PHRAppStatus.globalRealm addObject:_backgroundInfo];
    }
    
    [PHRAppStatus.globalRealm commitWriteTransaction];
//    PHRAppStatus.back = [[BackgroundSettingInfo allObjects] lastObject];
    PHRAppStatus.back = [[BackgroundSettingInfo objectsWhere:[NSString stringWithFormat:@"userID='%@'", PHRAppStatus.masterProfileId]] lastObject];
    //            [[PHRClient instance] requestChangeBackgroundBaby:_url_BG_Image];
    //        PHRAppStatus.babyBackgroundUrl = [NSString stringWithFormat:@"%@", _url_BG_Image];
}

- (void)actionNavigationBarItemRight {
    [self showPopupSetting];
}

#pragma mark - Save File Local

- (void)saveImageToBackGroundStandard:(NSString *)nameImage isBaby:(BOOL)isBaby {
    //    NSArray *paths = NSSearchPathForDirectoriesInDomains (NSDocumentDirectory, NSUserDomainMask, YES);
    //    NSString *documentsPath = [paths objectAtIndex:0];
    //    NSString *plistPath = [documentsPath stringByAppendingPathComponent:@"Configuration.plist"];
    //
    //    if (![[NSFileManager defaultManager] fileExistsAtPath:plistPath]) {
    //        plistPath = [[NSBundle mainBundle] pathForResource:@"Configuration" ofType:@"plist"];
    //    }
    //
    //    NSMutableDictionary *dictionary = [NSMutableDictionary dictionaryWithContentsOfFile:plistPath];
    
    if (isBaby) {
        //        [dictionary setObject:nameImage forKey:@"bGBaby"];
        //        [dictionary writeToFile:plistPath atomically:YES];
        PHRAppStatus.babyBackgroundUrl = nameImage;
    }
    else {
        //        [dictionary setObject:nameImage forKey:@"bGStandard"];
        //        [dictionary writeToFile:plistPath atomically:YES];
        PHRAppStatus.standardBackgroundUrl = nameImage;
    }
}

@end
