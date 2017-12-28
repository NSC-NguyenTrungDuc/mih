//
//  MedicineViewController.m
//  PHR
//
//  Created by BillyMobile on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "MedicineViewController.h"
#import "AddNewPresciptionViewController.h"
#import "BaseNetworking.h"
#import "PatientClinicViewModel.h"
#import "PatientClinicTableViewCell.h"
#import "ParseDataProgressCourse.h"

#define TODAY_DUG 65
#define PRESCRIPTION_LIST 65
#define TABLE_HEIGHT_CLINIC 86

#define TAG_TABLE_MEDICINES 200
#define TAG_TABLE_CLINIC 300

static NSString *MedicinePresciptionIdentifier     = @"presciption_list_cell";
static NSString *tagTableViewClinicCell = @"tagTableViewClinicCell";

@interface MedicineViewController (){
  
  NSString *_hospitalCode;
  NSString *_patientCode;
  NSURLSessionDataTask *taskGetTimeLine;
}

@property(strong, atomic) NSMutableArray *allNotifications;
@property(strong, nonatomic) NSMutableArray *listClinicModel;
@property(strong, nonatomic) NSArray *arrayAllModule;
@property(strong, nonatomic) NSMutableArray *arrayProgressCourseModule;
@property(strong, nonatomic) NSMutableArray *arrayListOrder;
@property(strong, nonatomic) NSDictionary *dictProgressCourseContent;
@property(strong, nonatomic) NSString *xmlProgressCourseContent;

@end

@implementation MedicineViewController

int listType = PHRMedicinePresciprionList;

- (void)viewDidLoad {
  [super viewDidLoad];
  
  _viewEmpty.hidden = YES;
  
  [self initializeMedicinesView];
  self.medicineTableView.hidden = YES;
  
  self.listClinicModel = [[NSMutableArray alloc] init];
  self.arrayPrescription = [[NSMutableArray alloc] init];
  self.arrayAllModule = [[NSMutableArray alloc] init];
  self.dictProgressCourseContent = [[NSDictionary alloc] init];
  self.arrayProgressCourseModule = [[NSMutableArray alloc] init];
  
  self.allNotifications = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] scheduledLocalNotifications]];
  
  [self requestPatientClinicWithProfileID:PHRAppStatus.currentStandard.profileId];
  
  self.tableViewClinic.tag = TAG_TABLE_CLINIC;
  self.medicineTableView.tag = TAG_TABLE_MEDICINES;
  
  [self cancelNotification];
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  [self setImageToBackgroundStandard:self.backgroundImage];
  
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileStandardActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(pullToRefreshData) name:kNotifyProfileStandardActiveChanged object:nil];
}

- (void)viewWillDisappear:(BOOL)animated {
  [super viewWillDisappear:animated];
  NSArray *viewControllers = self.navigationController.viewControllers;
  if ([viewControllers indexOfObject:self] == NSNotFound) {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
  }
}

- (void)requestPatientClinicWithProfileID:(NSString *)profileID {
  [self showOrHideLoading:YES];
  [BaseNetworking configureNetworkingWithHost:[[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_Clinic"]];
  NSString *URL = [NSString stringWithFormat:API_PHR03, profileID, PHRAppStatus.token];
  [[[BaseNetworking sharedInstance] fetchRequest:URL params:nil] continueWithBlock:^id _Nullable(BFTask * _Nonnull t) {
    [self showOrHideLoading:NO];
    if (t.cancelled) {
      DLog(@"Cancelled");
    } else if (t.faulted) {
      DLog(@"Error: %@", t.error)
    } else {
      DLog(@"______%@", t.result);
      [self handleResponseWithTask:t.result];
    }
    return nil;
  }];
}

- (void)handleResponseWithTask:(NSDictionary *)dictResponse {
  NSDictionary *dictContent = [dictResponse objectForKey:KEY_Content];
  
  if ([dictContent objectForKey:kPHR03ListAccountClinic] &&
      [dictContent objectForKey:kPHR03ListAccountClinic] != [NSNull null]) {
    NSArray *accountClinic = [dictContent objectForKey:kPHR03ListAccountClinic];
    for (id dictAccountClinic in accountClinic) {
      if (![dictAccountClinic isKindOfClass:[NSDictionary class]]) {
        break;
      }
      PatientClinicViewModel *viewModel = [[PatientClinicViewModel alloc] initWithModel:[[PatientClinic alloc] initWithDictionary:dictAccountClinic]];
      [self.listClinicModel addObject:viewModel];
    }
    //    if (listClinicModel.count == 0) {
    //      self.labelHospitalName.text = kLocalizedString(@"You don't have any clinic account.");
    //    }
    
    
    if (_listClinicModel.count == 0) {
      _viewEmpty.hidden = NO;
    }else{
      _viewEmpty.hidden = YES;
    }
      
    
    [self.tableViewClinic reloadData];
  }
}

- (void)showOrHideLoading:(BOOL)isShowed {
  if (isShowed) {
    [self.viewIndicator setHidden:NO];
  } else {
    [self.viewIndicator setHidden:YES];
  }
}

- (void)pullToRefreshData {
  [self.arrayPrescription removeAllObjects];
  [self.medicineTableView reloadData];
  [self cancelNotification];
}

- (void)cancelNotification {
  
  for(PresciptionObject *pres in self.arrayPrescription){
    for (UILocalNotification *noti in self.allNotifications) {
      NSString *presID = [noti.userInfo valueForKey:@"ID"];
      
      if(presID !=nil && [[NSString stringWithFormat:@"%@",presID] containsString:[NSString stringWithFormat:@"PresKey%@",pres.prescription_id]]){
      } else {
        [[UIApplication sharedApplication] cancelLocalNotification:noti];
      }
    }
  }
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
}

- (void)initializeMedicinesView {
  
  [self setupNavigationBarTitle:kLocalizedString(kTitleMedicine) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Medicine Note" isDismissView:false colorLeft:[PHR_COLOR_MEDICINE_OVERLAY colorWithAlphaComponent:0.6]colorRight:[PHR_COLOR_MEDICINE_MAIN_COLOR colorWithAlphaComponent:0.6]];
  
  __weak __typeof__(self) weakSelf = self;
  [self.navBarRightIcon setActionBack:^(){
    if (weakSelf.medicineTableView.hidden) {
      [weakSelf.navigationController popViewControllerAnimated:YES];
    } else {
      weakSelf.medicineTableView.hidden = YES;
      [weakSelf.arrayPrescription removeAllObjects];
      [weakSelf.medicineTableView reloadData];
    }
  }];
  
  
  [self.medicineTableView registerNib:[UINib nibWithNibName:NSStringFromClass([TodayDrugTableViewCell class]) bundle:nil] forCellReuseIdentifier:@"today_drug_cell"];
  [self.medicineTableView registerNib:[UINib nibWithNibName:NSStringFromClass([PresciptionListTableViewCell class]) bundle:nil] forCellReuseIdentifier:MedicinePresciptionIdentifier];
  
  self.lblPrescriptionList.font = [FontUtils aileronRegularWithSize:15.0];
  self.lblPrescriptionList.text = kLocalizedString(kPrescriptionList);
  self.viewTabbar.backgroundColor = [PHR_COLOR_MEDICINE_MAIN_COLOR colorWithAlphaComponent:0.3];
  
  self.medicineTableView.showsHorizontalScrollIndicator = NO;
  self.medicineTableView.showsVerticalScrollIndicator = NO;
  
  [self.medicineTableView setDelegate:self];
  [self.medicineTableView setDataSource:self];
  
  [self.tableViewClinic registerNib:[UINib nibWithNibName:@"PatientClinicTableViewCell" bundle:nil] forCellReuseIdentifier:tagTableViewClinicCell];
  [self.tableViewClinic setDelegate:self];
  [self.tableViewClinic setDataSource:self];
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  return 1.0;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  if (tableView.tag == TAG_TABLE_MEDICINES) {
    return self.arrayPrescription.count;
  } else {
    return self.listClinicModel.count;
  }
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  if (tableView.tag == TAG_TABLE_MEDICINES) {
    if(listType == PHRMedicineTodayDrug) {
      TodayDrugTableViewCell *cell = [self.medicineTableView dequeueReusableCellWithIdentifier:@"today_drug_cell" forIndexPath:indexPath];
      if (!cell) {
        cell = [[TodayDrugTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"today_drug_cell"];
      }
      
      if(indexPath.row % 2){
        cell.viewContent.backgroundColor = [UIColor colorWithRed:246.0/255.0 green:246.0/255.0 blue:246.0/255.0 alpha:1.0];
      }
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      
      return cell;
    } else {
      PresciptionListTableViewCell *cell = [self.medicineTableView dequeueReusableCellWithIdentifier:MedicinePresciptionIdentifier forIndexPath:indexPath];
      if (!cell) {
        cell = [[PresciptionListTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:MedicinePresciptionIdentifier];
      }
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      
      PresciptionObject *objPres = ([self.arrayPrescription objectAtIndex:indexPath.row]);
      
      cell.lblPresciption.text = objPres.prescription_name;
      DLog(@" Prescrip %@",objPres.prescription_name);
      //      cell.lblDateTime.text = [UIUtils stringDate:[UIUtils dateFromString:objPres.datetime_record withFormat:PHR_SERVER_DATE_TIME_FORMAT] withFormat:PHR_CLIENT_TIME_FORMAT_FULL];
      cell.lblDateTime.text = objPres.datetime_record;
      
      
      return cell;
    }
  } else {
    PatientClinicTableViewCell *cell = (PatientClinicTableViewCell*) [tableView dequeueReusableCellWithIdentifier:tagTableViewClinicCell forIndexPath:indexPath];
    [cell setViewModelForCell:self.listClinicModel[indexPath.row]];
    return cell;
  }
  return nil;
  
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  if (tableView.tag == TAG_TABLE_MEDICINES) {
    
    AddNewPresciptionViewController *controller = [[AddNewPresciptionViewController alloc] initWithNibName:NSStringFromClass([AddNewPresciptionViewController class]) bundle:nil];
    controller.type = self.type;
    controller.data = [self.arrayPrescription objectAtIndex:indexPath.row];
    [self.navigationController pushViewController:controller animated:YES];
  } else {
    self.medicineTableView.hidden = NO;
    PatientClinicViewModel *patientModel = [self.listClinicModel objectAtIndex:indexPath.row];
    
    [self getProgressCourse:patientModel.model.hospName hospitalCode:patientModel.model.hospCode andPatientCode:patientModel.model.patientCode];
  }
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  if (tableView.tag == TAG_TABLE_MEDICINES) {
    if(listType == PHRMedicineTodayDrug){
      return TODAY_DUG;
    } else {
      return PRESCRIPTION_LIST;
    }
  } else {
    return TABLE_HEIGHT_CLINIC;
  }
}

#pragma mark - Parse data
- (void)getProgressCourse:(NSString*)hospitalName hospitalCode:(NSString*)hospitalCode andPatientCode:(NSString*)patientCode {
  
  [self.arrayPrescription removeAllObjects];
  [self.medicineTableView reloadData];
  [self showOrHideLoading:YES];
  if (hospitalCode && patientCode && ![hospitalCode isEmpty] && ![patientCode isEmpty]) {
    _hospitalCode = hospitalCode;
    _patientCode = patientCode;
    [self getAndParseData:hospitalCode andPatientCode:patientCode];
  }
}

- (void)getAndParseData:(NSString*)hospitalCode andPatientCode:(NSString*)patientCode {
  
  [[EMRClient instance] requestGetDetailProgressCourse:hospitalCode andPatientCode:patientCode completion:^(MFRession *response) {
    // PROCESS DATA FOR EMR
    if (response.content && response.content[KEY_Content]) {
      NSString *strResponse = response.content[KEY_Content];
      if (!strResponse || strResponse == (id)[NSNull null] || strResponse.length == 0 || strResponse.isEmpty) {
        [self showOrHideLoading:NO];
        return;
      }
      NSString *xmlString = [NSString stringWithCString:[strResponse UTF8String] encoding:NSUTF8StringEncoding];
      if (xmlString && ![xmlString isEmpty]) {
        self.xmlProgressCourseContent  = [ParseDataProgressCourse replaceWrongXMLData:xmlString];
        
        self.dictProgressCourseContent = [NSDictionary dictionaryWithXMLString:_xmlProgressCourseContent];
        self.arrayAllModule = [_dictProgressCourseContent arrayValueForKeyPath:KEYPath_GetMmlModuleItem];
        NSArray *arrayModule = [ParseDataProgressCourse getProgressCourseModule:_arrayAllModule];
        self.arrayProgressCourseModule = [arrayModule objectAtIndex:0];
        self.arrayListOrder = [ParseDataProgressCourse getProgressCourseModuleOrderList:_arrayProgressCourseModule];
        
        NSMutableArray *discardItem = [NSMutableArray new];
        for (NSArray *arr in self.arrayListOrder) {
          if (arr.count == 0) {
            [discardItem addObject:arr];
          }
        }
        [self.arrayListOrder removeObjectsInArray:discardItem];
        
        for (NSMutableArray *arr in self.arrayListOrder) {
          PresciptionObject *prescriptionObj = [[PresciptionObject alloc] init];
          OrderModel* orderModel = [arr objectAtIndex:0];
          prescriptionObj.prescription_name = orderModel.NaewonKey;
          prescriptionObj.datetime_record = orderModel.NaewonDate;
          prescriptionObj.prescription_id = orderModel.NaewonKey;
          prescriptionObj.listOrderModel = arr;
          [self.arrayPrescription addObject:prescriptionObj];
        }
        [self.medicineTableView reloadData];
        [self showOrHideLoading:NO];
      } else {
        [self showOrHideLoading:NO];
      }
    } else {
      [self showOrHideLoading:NO];
    }
  }];
}



@end
