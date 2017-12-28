//
//  AddBabyPrescriptionViewController.m
//  PHR
//
//  Created by BillyMobile on 7/21/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddBabyPrescriptionViewController.h"
#import "AddNewDrugTableViewCell.h"
#import "AddRemiderTableViewCell.h"
#import "AddNewDrugFooter.h"
#import "AddNewDrugHeader.h"
#import "AddNewRemiderFooter.h"
#import "AddNewRemiderHeader.h"
#import "AddNewDrugViewController.h"
#import "IQActionSheetPickerView.h"
#import "AddChildrenDrugViewController.h"
#import "AddNewReminderViewController.h"
#import "UploadImagesCollectionViewCell.h"

#define MAX_UPLOAD_IMAGES 3
#define IMAGES_SIZE 80

@interface AddBabyPrescriptionViewController () {
  bool isExpant;
  int pageNumber;
  int _numberIMG;
  int numberUploadImage;
}
@property (strong, nonatomic) NSDate *timeRecord;

@end

@implementation AddBabyPrescriptionViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  [self.tableViewContent setDelegate:self];
  [self.tableViewContent setDataSource:self];
  [self.collectionViewUploadImages setDataSource:self];
  [self.collectionViewUploadImages setDelegate:self];
  [self.collectionViewUploadImages registerNib:[UINib nibWithNibName:NSStringFromClass([UploadImagesCollectionViewCell class])
                                                              bundle:nil]
                    forCellWithReuseIdentifier:@"UploadImagesCollectionViewCell"];
  
  UICollectionViewFlowLayout *layoutFlow =  [[UICollectionViewFlowLayout alloc]init];
  layoutFlow.itemSize = CGSizeMake(IMAGES_SIZE, IMAGES_SIZE);
  layoutFlow.scrollDirection = UICollectionViewScrollDirectionHorizontal;
  [self.collectionViewUploadImages setCollectionViewLayout:layoutFlow];
  [self.collectionViewUploadImages setShowsVerticalScrollIndicator:NO];
  [self.collectionViewUploadImages setShowsHorizontalScrollIndicator:NO];
  
  self.arrayUploadImages = [[NSMutableArray alloc] init];
  self.arrayDrug = [[NSMutableArray alloc] init];
  numberUploadImage = 0;
  [self getListImageURLFromString:self.prescriptionItem.prescription_url];
  
  pageNumber = 1;
  
  
  NSString *apiId = PHRAppStatus.currentStandard.profileId;
  NSString *prescriptionId = self.prescriptionItem.prescription_id;
  
  self.timeRecord = [NSDate date];
  NSMutableAttributedString *titleString;
  
  if([NSUtils checkDateIsToday:self.timeRecord]) {
    titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday),[UIUtils remiderTimeStringFromDate:self.timeRecord]]] ;
  } else {
    titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
  }
  [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
  
  [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];
  
  [self initializeAddNewPresciption];
  
  if(apiId != nil && prescriptionId != nil) {
    [self requestGetListDrugWithProfileId:apiId andPresciptionId:prescriptionId];
  }
  
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (void)getListImageURLFromString:(NSString*)strImageURL {
  
  numberUploadImage = 0;
  
  if (!strImageURL || strImageURL == (id)[NSNull null] || strImageURL.length == 0 || strImageURL.isEmpty) {
    return;
  }
  NSData * jsonData = [strImageURL dataUsingEncoding:NSUTF8StringEncoding];
  NSError *jsonError;
  NSArray *parsedData = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingAllowFragments error:&jsonError];
  for (int i = 0;i < parsedData.count; i++) {
    ImageUpload *imageUpload = [[ImageUpload alloc] init];
    imageUpload.url = [parsedData objectAtIndex:i];
    [self.arrayUploadImages addObject:imageUpload];
  }
  
 // NSLog(@"%lu",(unsigned long)_arrayUploadImages.count);
  //numberUploadImage = (int)_arrayUploadImages.count;
  
}

- (void)initializeAddNewPresciption {
  [self setupNavigationBarTitle:kLocalizedString(kBabyTitleMedicine) iconLeft:@"backMenuBar" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:nil colorRight:nil];
  
  self.lblDateTime.text = kLocalizedString(kDATETIME);
  self.txtPrescriptionName.placeholder = kLocalizedString(kPrescriptionName);
  self.btnChooseTime.titleLabel.textColor = [UIColor blackColor];
  self.lblSave.text = kLocalizedString(kSave);
  
  if(self.isUpdate){
    [self fillData:self.prescriptionItem];
    // Get notification list with ID
    self.arrayNotification = [[NSMutableArray alloc]init];
    NSMutableArray *allNotifications = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] scheduledLocalNotifications]];
    for (UILocalNotification *noti in allNotifications) {
      NSString *presID = [noti.userInfo valueForKey:@"ID"];
      
      DLog(@"Notifi Infoxxx %@",noti.userInfo);
      
      if(presID !=nil && [[NSString stringWithFormat:@"%@",presID] containsString:[NSString stringWithFormat:@"PresKey%@",self.prescriptionItem.prescription_id]]){
        [self.arrayNotification addObject:noti];
      }
    }
  }
  
  [self checkProfileToShowView];
  
  [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddRemiderTableViewCell class]) bundle:nil] forCellReuseIdentifier:@"add_remider_cell"];
  [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewRemiderHeader class]) bundle:nil] forCellReuseIdentifier:@"add_remider_header_cell"];
  [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewRemiderFooter class]) bundle:nil] forCellReuseIdentifier:@"add_remider_footer_cell"];
  
  [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewDrugTableViewCell class]) bundle:nil] forCellReuseIdentifier:@"add_new_drug_cell"];
  [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewDrugHeader class]) bundle:nil] forCellReuseIdentifier:@"add_new_drug_header_cell"];
  [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewDrugFooter class]) bundle:nil] forCellReuseIdentifier:@"add_new_drug_footer_cell"];
  
  self.tableViewContent.showsHorizontalScrollIndicator = NO;
  self.tableViewContent.showsVerticalScrollIndicator = NO;
  [self.imageBackground setImage:[self.imageBG applyLowLightEffect]];
  self.viewAdd.backgroundColor = [UIColor colorWithRed:238.0/255.0 green:145.0/255.0 blue:128.0/255.0 alpha:1.0];
  [self.viewOpacity setBackgroundColor:PHR_COLOR_MEDICINE_OVERLAY];
}

- (void)checkProfileToShowView {
  if (![PHRAppStatus checkCurrentBabyActive]) {
    [self.viewAdd setHidden:YES];
    self.constraintTableAndAdd.constant = 0 - self.viewAdd.bounds.size.height;
  } else {
    [self.viewAdd setHidden:NO];
    self.constraintTableAndAdd.constant = 0;
  }
}


-(void)fillData:(PresciptionObject *)prescriptionItem{
  self.txtPrescriptionName.text = self.prescriptionItem.prescription_name;
  self.timeRecord = [UIUtils dateFromString:prescriptionItem.datetime_record withFormat:PHR_SERVER_DATE_TIME_FORMAT];
  NSMutableAttributedString *titleString;
  
  if([NSUtils checkDateIsToday:self.timeRecord]) {
    titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday),[UIUtils remiderTimeStringFromDate:self.timeRecord]]] ;
  } else {
    titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
  }
  [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
  
  [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];
  
  //    [self.dateTimeView updateTime:[UIUtils dateFromString:self.prescriptionItem.datetime_record withFormat:PHR_SERVER_DATE_TIME_FORMAT] shortFormat:NO];
}

- (NSString*)stringDateWithShortFormat {
  return [UIUtils stringDate:self.timeRecord withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE];
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  return 2;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  if(section == PHRMedicineAddRemider){
    return self.arrayNotification.count + 1;
  } else {
    return self.arrayDrug.count+1;
  }
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  if(indexPath.section == PHRMedicineAddRemider){
    
    if(indexPath.row == 0){
      AddNewRemiderHeader *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:@"add_remider_header_cell" forIndexPath:indexPath];
      if (!cell) {
        cell = [[AddNewRemiderHeader alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_remider_header_cell"];
      }
      
      [cell setAddRemiderCallBack:^(){
        AddNewReminderViewController *controller = [[AddNewReminderViewController alloc] initWithNibName:NSStringFromClass([AddNewReminderViewController class]) bundle:nil];
        [controller setSaveCallBack:^(NSDate *remindDate, int numberOfDay) {
          [self createLocalNotification:remindDate withAddingDateInterval:numberOfDay];
        }];
        [self presentViewController:controller animated:YES completion:nil];
      }];
      
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      
      return cell;
    } else if(indexPath.row == self.arrayNotification.count+1){
      
      AddNewRemiderFooter *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:@"add_remider_footer_cell" forIndexPath:indexPath];
      if (!cell) {
        cell = [[AddNewRemiderFooter alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_remider_footer_cell"];
      }
      
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      
      [cell setAddRemiderCallBack:^(){
        // Date picker
        IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:nil delegate:self];
        [picker setButtonColor:[UIColor colorWithRed:0.0 green:122.0/255.0 blue:1.0 alpha:1.0]];
        [picker setTag:1];
        [picker setActionSheetPickerStyle:IQActionSheetPickerStyleTimePicker];
        //[picker setDate:self.datetime];
        [picker show];
      }];
      return cell;
      
    } else {
      AddRemiderTableViewCell *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:@"add_remider_cell" forIndexPath:indexPath];
      if (!cell) {
        cell = [[AddRemiderTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_remider_cell"];
        cell.selectionStyle = UITableViewCellSelectionStyleNone;
      }
      UILocalNotification *localNotification = [self.arrayNotification objectAtIndex:indexPath.row-1];
      cell.lblTime.text = [UIUtils remiderTimeStringFromDate:localNotification.fireDate];
      __block NSInteger row = indexPath.row;
      [cell setOnRemoveRemider:^(){
        // Remove from list
        [self.arrayNotification removeObjectAtIndex:row - 1];
        // Cancel reminder
        [[UIApplication sharedApplication] cancelLocalNotification:localNotification];
        
        // reload table
        [self.tableViewContent reloadData];
      }];
      
      return cell;
    }
    
  } else {
    if(indexPath.row == 0){
      AddNewDrugHeader *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:@"add_new_drug_header_cell" forIndexPath:indexPath];
      cell.isShowAdd = YES;
      if (!cell) {
        cell = [[AddNewDrugHeader alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_new_drug_header_cell"];
      }
      
      cell.btnAddDrug.hidden = NO;
      
      [cell setAddDrugCallBack:^(){
        if (self.prescriptionItem.prescription_id == nil || self.prescriptionItem.prescription_id  == (id)[NSNull null] ) {
          [NSUtils showMessage:kLocalizedString(kCreatePrescriptionBeforeAdd) withTitle:APP_NAME];
        } else {
          AddChildrenDrugViewController *controller = [[AddChildrenDrugViewController alloc] initWithNibName:NSStringFromClass([AddChildrenDrugViewController class]) bundle:nil];
          controller.isUpdate = NO;
          controller.presID = self.prescriptionItem.prescription_id;
          [controller setAddDrugCallBack:^(){
            [self refreshData];
          }];
          controller.imgBackground = [UIUtils screenshot:self.view];
          [self presentViewController:controller animated:YES completion:nil];
        }
      }];
      
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      
      return cell;
      
    } else if(indexPath.row == [self.arrayDrug count]+1) {
      
      AddNewDrugFooter *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:@"add_new_drug_footer_cell" forIndexPath:indexPath];
      if (!cell) {
        cell = [[AddNewDrugFooter alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_new_drug_footer_cell"];
      }
      
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      
      [cell setAddDrugCallBack:^(){
        AddChildrenDrugViewController *controller = [[AddChildrenDrugViewController alloc] initWithNibName:NSStringFromClass([AddChildrenDrugViewController class]) bundle:nil];
        controller.isUpdate = NO;
        controller.presID = self.prescriptionItem.prescription_id;
        [controller setAddDrugCallBack:^(){
          [self refreshData];
        }];
        controller.imgBackground = [UIUtils screenshot:self.view];
        [self presentViewController:controller animated:YES completion:nil];
      }];
      
      return cell;
      
    } else {
      
      AddNewDrugTableViewCell *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:@"add_new_drug_cell" forIndexPath:indexPath];
      if (!cell) {
        cell = [[AddNewDrugTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_new_drug_cell"];
      }
      
      DrugNote  *obj = ([self.arrayDrug objectAtIndex:indexPath.row-1]);
      
      cell.lblDrugName.text = obj.drug_name;
      //cell.lblRemider.text = [NSString stringWithFormat:@"%@ %@ %@",obj.quantity  ];
      DLog(@"Method %@",obj.method);
      if([obj.method isEqualToString:@"1"]){
        
        cell.imgDrugIcon.image = [UIImage imageNamed:@"Icon_drink_drug_disabled"];
        
      }else{
        cell.imgDrugIcon.image = [UIImage imageNamed:@"Icon_external_drug_disabled"];
      }
      
      [cell setDeleteCallBack:^(){
        DrugNote  *obj = ([self.arrayDrug objectAtIndex:indexPath.row-1]);
        [self requestDeleteDrug:self.prescriptionItem.prescription_id andDrugID:obj.drug_id];
        
      }];
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      return cell;
    }
  }
}

- (void)createLocalNotification:(NSDate*)date withAddingDateInterval:(int)addingDate {
  UILocalNotification* localNotification = [[UILocalNotification alloc] init];
  NSTimeInterval time = floor([date timeIntervalSinceReferenceDate] / 60.0) * 60.0;
  NSDate *dateWithoutSecond = [NSDate dateWithTimeIntervalSinceReferenceDate:time];
  
  localNotification.fireDate = dateWithoutSecond;
  localNotification.alertBody = kLocalizedString(kTakeYourMedicine);
  localNotification.alertAction = @"Show me the item";
  localNotification.repeatInterval = NSCalendarUnitDay;
  localNotification.timeZone = [NSTimeZone systemTimeZone];
  localNotification.soundName = UILocalNotificationDefaultSoundName;// @"Sound name";
  
  NSString *keyNotification = [NSString stringWithFormat:@"%@AndPresKey%@",[UIUtils stringDate:localNotification.fireDate withFormat:PHR_CLIENT_TIME_FORMAT_FULL],[NSString stringWithFormat:@"%@",self.prescriptionItem.prescription_id]];
  NSDate *keyEndDate = [date dateByAddingTimeInterval:addingDate * 86400];
  NSMutableDictionary *userInfo = [NSMutableDictionary dictionaryWithObject:keyNotification forKey:@"ID"];
  [userInfo setObject:keyEndDate forKey:PHR_REMIND_END_DATE];
  localNotification.userInfo = userInfo;
  
  //localNotification.applicationIconBadgeNumber = [[UIApplication sharedApplication] applicationIconBadgeNumber] + 1;
  [[UIApplication sharedApplication] scheduleLocalNotification:localNotification];
  [self.arrayNotification addObject:localNotification];
  
  [self.tableViewContent reloadData];
  
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  if(indexPath.section != PHRMedicineAddRemider){
    if(indexPath.row >0 && indexPath.row < self.arrayDrug.count+1){
      AddChildrenDrugViewController *controller = [[AddChildrenDrugViewController alloc] initWithNibName:NSStringFromClass([AddChildrenDrugViewController class]) bundle:nil];
      
      DrugNote  *obj = ([self.arrayDrug objectAtIndex:indexPath.row-1]);
      DLog(@"Row: %lu and arr %lu",indexPath.row,self.arrayNotification.count+1);
      controller.drugNote = obj;
      
      controller.isUpdate = YES;
      controller.presID = self.prescriptionItem.prescription_id;
      [controller setAddDrugCallBack:^(){
        [self refreshData];
      }];
      
      controller.imgBackground = [UIUtils screenshot:self.view];
      [self presentViewController:controller animated:YES completion:nil];
    }
  }
}


- (void)addNewPresscription:(NSString*)prescriptionID {
  [PHRAppDelegate showLoading];
  if(self.txtPrescriptionName.text.length > 128) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kTextInputLong)];
    return;
  }
  NSMutableArray *arrayURL = [[NSMutableArray alloc] init];
  for (int i = 0; i < self.arrayUploadImages.count; i++) {
    ImageUpload *imageUpload = [self.arrayUploadImages objectAtIndex:i];
    [arrayURL addObject:imageUpload.url];
  }
  [[PHRClient instance] requestAddNewPrescription:prescriptionID andPres:self.txtPrescriptionName.text andDate:[UIUtils stringUTCDate:self.timeRecord withFormat:PHR_SERVER_DATE_TIME_FORMAT] withArrayImages:arrayURL completed:^(id response) {
    [PHRAppDelegate hideLoading];
    if (response) {
      BOOL status = [PHRClient getStatusFromResponse:response];
      if(status){
        NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
        NSLog(@"%@",newDict);
        self.addPrescriptionCallBack();
        [self dismissViewControllerAnimated:YES completion:nil];
      } else {
        NSString* message = [PHRClient getMessageFromResponse:response];
        [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
      }
    }
    
  } error:^(NSString *error){
    [PHRAppDelegate hideLoading];
    [NSUtils showMessage:error withTitle:APP_NAME];
  }];
}

- (void)requestDeleteDrug:(NSString *)presID andDrugID:(NSString *)drugID{
  [[PHRClient instance] requestDeleteDrug:presID andDrugID:drugID completed:^(id response){
    [PHRAppDelegate hideLoading];
    if (response) {
      BOOL status = [PHRClient getStatusFromResponse:response];
      if(status){
        NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
        NSLog(@"%@",newDict);
        [self refreshData];
        [self.tableViewContent reloadData];
      } else {
        NSString* message = [PHRClient getMessageFromResponse:response];
        [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
      }
    }
    
  } error:^(NSString *error){
    [PHRAppDelegate hideLoading];
    [NSUtils showMessage:error withTitle:APP_NAME];
  }];
  
}

- (void)requestGetListDrugWithProfileId:(NSString *)profileId andPresciptionId:(NSString *) presciptionId{
  __weak __typeof__(self) weafSelf = self;
  //[PHRAppDelegate showLoading];
  [[PHRClient instance] requestDrugsWithApiID:profileId andPrescriptionId:presciptionId andNumberPage:pageNumber andCompleted:^(id params) {
    id response = [params objectForKey:KEY_Content];
    id drugList = [response objectForKey:KEY_Medicine_List];
    if ([drugList isKindOfClass:[NSArray class]]) {
      NSArray *resulPrescriptions = (NSArray *)drugList;
      
      for (int i = 0; i < resulPrescriptions.count; i++) {
        NSDictionary *dict = [resulPrescriptions objectAtIndex:i];
        DrugNote *objNote = [DrugNote initializeMedicinFrom:dict];
        [weafSelf.arrayDrug addObject:objNote];
      }
      
    }
    
    [self.tableViewContent reloadData];
  } error:^(NSString *error) {
    [PHRAppDelegate hideLoading];
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
  }];
  
}

- (void)refreshData {
  
  pageNumber = 1;
  [self.arrayDrug removeAllObjects];
  NSString *apiId = PHRAppStatus.currentBaby.profileId;
  [self requestGetListDrugWithProfileId:apiId andPresciptionId:self.prescriptionItem.prescription_id];
}

- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectDate:(NSDate*)date{
  if(pickerView.tag == 1){
    UILocalNotification* localNotification = [[UILocalNotification alloc] init];
    NSTimeInterval time = floor([date timeIntervalSinceReferenceDate] / 60.0) * 60.0;
    NSDate *dateWithoutSecond = [NSDate dateWithTimeIntervalSinceReferenceDate:time];
    localNotification.fireDate = dateWithoutSecond;
    localNotification.alertBody = kLocalizedString(kTakeYourMedicine);
    localNotification.alertAction = @"Show me the item";
    localNotification.repeatInterval = NSCalendarUnitDay;
    localNotification.timeZone = [NSTimeZone systemTimeZone];
    localNotification.soundName = UILocalNotificationDefaultSoundName;// @"Sound name";
    
    NSString *keyNotification = [NSString stringWithFormat:@"%@AndPresKey%@",[UIUtils stringDate:localNotification.fireDate withFormat:PHR_CLIENT_TIME_FORMAT_FULL],[NSString stringWithFormat:@"%@",self.prescriptionItem.prescription_id]];
    
    NSDictionary *userInfo = [NSDictionary dictionaryWithObject:keyNotification forKey:@"ID"];
    localNotification.userInfo = userInfo;
    
    //localNotification.applicationIconBadgeNumber = [[UIApplication sharedApplication] applicationIconBadgeNumber] + 1;
    [[UIApplication sharedApplication] scheduleLocalNotification:localNotification];
    [self.arrayNotification addObject:localNotification];
    
    [self.tableViewContent reloadData];
    
  } else {
    self.timeRecord = date;
    NSMutableAttributedString *titleString;
    
    if([NSUtils checkDateIsToday:self.timeRecord]) {
      titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday),[UIUtils remiderTimeStringFromDate:self.timeRecord]]] ;
    } else {
      titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
    }
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];
    
    [self.btnChooseTime setAttributedTitle:titleString forState:UIControlStateNormal];
  }
}

- (IBAction)actionChooseTime:(id)sender {
  
  // Date picker
  IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:nil delegate:self];
  [picker setTag:2];
  [picker setButtonColor:[UIColor colorWithRed:0.0 green:122.0/255.0 blue:1.0 alpha:1.0]];
  [picker setActionSheetPickerStyle:IQActionSheetPickerStyleDateTimePicker];
  [picker setDate:[NSDate date]];
  [picker setMaximumDate:[NSDate date]];
  [picker show];
}

- (IBAction)actionSaveData:(id)sender {
  if (_arrayUploadImages.count > 0) {
    [self usingNSOperationQueueToLoadImage];
  } else {
    [self createPrescription];
  }
}

- (void)createPrescription {
  NSString *prescription = self.txtPrescriptionName.text;
  if (!prescription || [prescription isEmpty]) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kEnterPrescriptionName)];
    return;
  }
  if (self.isUpdate) {
    [self addNewPresscription:self.prescriptionItem.prescription_id];
  } else {
    [self addNewPresscription:nil];
  }
}

#pragma mark -  Methods Pick Image from gallery
- (void)assetsPickerController:(CTAssetsPickerController *)picker didFinishPickingAssets:(NSArray *)assets {
  PHImageRequestOptions *requestOptions = [[PHImageRequestOptions alloc] init];
  requestOptions.resizeMode   = PHImageRequestOptionsResizeModeExact;
  requestOptions.deliveryMode = PHImageRequestOptionsDeliveryModeHighQualityFormat;
  
  [assets enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
    PHImageManager *manager = [PHImageManager defaultManager];
    CGFloat scale = UIScreen.mainScreen.scale;
    CGSize targetSize = CGSizeMake(IMAGES_SIZE * scale,IMAGES_SIZE * scale);
    
    [manager ctassetsPickerRequestImageForAsset:[assets objectAtIndex:(int)idx]
                                     targetSize:targetSize
                                    contentMode:PHImageContentModeAspectFill
                                        options:requestOptions
                                  resultHandler:^(UIImage *image, NSDictionary *info){
                                    ImageUpload *imageUpload = [[ImageUpload alloc] init];
                                    imageUpload.image = image;
                                    [self.arrayUploadImages addObject:imageUpload];
                                    if (idx == assets.count - 1) {
                                      dispatch_async(dispatch_get_main_queue(), ^{
                                        [self.collectionViewUploadImages reloadData];
                                      });
                                    }
                                  }];
    
  }];
  [picker dismissViewControllerAnimated:YES completion:nil];
  
}

- (BOOL)assetsPickerController:(CTAssetsPickerController *)picker shouldSelectAsset:(PHAsset *)asset {
  NSInteger max = MAX_UPLOAD_IMAGES - _arrayUploadImages.count;
  if (picker.selectedAssets.count >= max) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
  }
  return (picker.selectedAssets.count < max);
}

- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {
  UploadImagesCollectionViewCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:@"UploadImagesCollectionViewCell" forIndexPath:indexPath];
  if (indexPath.row == _arrayUploadImages.count) {
    cell.imgUpload.hidden = YES;
    cell.btnClose.hidden = YES;
    cell.btnAdd.hidden = NO;
    cell.layer.borderColor  = [UIColor blackColor].CGColor;
    cell.layer.borderWidth  = 1;
    cell.layer.cornerRadius  = 8;
  } else {
    ImageUpload *imageUpload = [_arrayUploadImages objectAtIndex:indexPath.row];
    if (imageUpload.image) {
      cell.imgUpload.image = imageUpload.image;
    } else {
      [cell.imgUpload sd_setImageWithURL:[NSURL URLWithString:imageUpload.url] placeholderImage:[UIImage imageNamed:@"IconCamera"] options:SDWebImageRefreshCached];
    }
    cell.imgUpload.hidden = NO;
    cell.btnClose.hidden = NO;
    cell.btnAdd.hidden = YES;
    cell.layer.borderColor  = [UIColor clearColor].CGColor;
    __weak __typeof__(self) weakSelf = self;
    [cell setDeleteImageCallBack:^{
      [weakSelf.arrayUploadImages removeObjectAtIndex:indexPath.row];
      [weakSelf.collectionViewUploadImages reloadData];
    }];
  }
  return cell;
}

- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {
  return _arrayUploadImages.count + 1;
}

- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath {
  if (indexPath.row == _arrayUploadImages.count) {
    [NSUtils createPhotoLibrary:self andViewController:self];
  }
}

- (void)usingNSOperationQueueToLoadImage {
  [PHRAppDelegate showLoading];
  NSOperationQueue *operationQueue = [NSOperationQueue new];
  [operationQueue setMaxConcurrentOperationCount:10];
  
  for(ImageUpload *objImg in _arrayUploadImages) {
    if (objImg && objImg.image) {
      numberUploadImage += 1;
      NSInvocationOperation *operation = [[NSInvocationOperation alloc] initWithTarget:self selector:@selector(processUploadImageInNewThread:) object:objImg];
      [operationQueue addOperation:operation];
    }
  }
  
  if (numberUploadImage == 0) {
    [self createPrescription];
  }
}

- (void)processUploadImageInNewThread:(ImageUpload*)imageUpload {
  __weak __typeof(self) weakSelf = self;
  _numberIMG = 0;
  [[PHRClient instance] uploadProfileImageToServer:imageUpload.image andCompletion:^(id responseObject) {
    if (responseObject == nil) {
      dispatch_async(dispatch_get_main_queue(), ^{
        [PHRAppDelegate hideLoading];
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
      });
    } else {
      NSString *url = [Validator getSafeString:responseObject[@"content"]];
      for(ImageUpload *objImg in _arrayUploadImages) {
        if (objImg == imageUpload) {
          imageUpload.url = url;
        }
      }
      
      
      _numberIMG += 1;
      if (_numberIMG == numberUploadImage) {
        [weakSelf createPrescription];
      }
    }
  }];
}

@end
