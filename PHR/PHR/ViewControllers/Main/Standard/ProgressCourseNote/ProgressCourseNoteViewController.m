//
//  ProgressCourseNoteViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 10/5/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

/*
 {
 "content": {
 "id": 242,
 "profile_id": 247,
 "hosp_code": "346",
 "hosp_name": "三杯",
 "patient_code": "000000007",
 "active_clinic_account_flg": 0
 },
 "message": "message.success",
 "status": "SUCCESS"
 }
 */

#import "ProgressCourseNoteViewController.h"
#import "DiseasesModel.h"
#import "ParseDataProgressCourse.h"


@interface ProgressCourseNoteViewController ()<PHRViewUploadFileDelegate> {
  NSMutableArray *arrayFileNameUpload;
  NSMutableArray *_arrayUploadImage;
  NSMutableArray *_listImgURL;
  NSMutableArray *_listImgNameFile;
  int _numberIMG, _maxImage;
  BOOL _isShow;
  NSString *_hospitalCode;
  NSString *_patientCode;
  BOOL isClicked;
}
@property (nonatomic,strong) NSString* xmlProgressCourseContent;
@property (nonatomic,strong) NSDictionary* dictProgressCourseContent;
@property (nonatomic,strong) NSArray *arrayAllModule;
@property (nonatomic,strong) NSMutableArray *arrayProgressCourseModule;
@property (nonatomic,strong) NSMutableArray *arrayDiseasesModule;
@property (nonatomic,strong) NSMutableArray *arrayListOrder;
@property (nonatomic,strong) NSMutableArray *arrayListPlanNotes;
@property (nonatomic,strong) NSMutableArray *arrayDateTime;
@property (nonatomic,strong) NSMutableArray *arrayEMR;
@property (nonatomic,strong) NSMutableArray *arrayAllDateTime;
@property (nonatomic,strong) NSMutableArray *arrayPlannotesSame;
@property (nonatomic,strong) NSMutableArray *arrayDataForEachSection;
@property (nonatomic,strong) NSMutableArray *arrayMedicineNote;
@property (nonatomic, strong) NSMutableArray *listViewModel;
@end

static NSString *XML_WRONG_LT = @"&lt;";
static NSString *XML_WRONG_GT = @"&gt;";
static NSString *XML_RIGHT_LT = @"<";
static NSString *XML_RIGHT_GT = @">";
static NSString *tagTableViewCellIdenifier = @"tagTableViewCell";
static NSString *orderTableViewCellIdenifier = @"orderTableViewCell";
static NSString *headerTableViewCellIdenifier = @"progressHeaderCell";
static NSString *tagTableViewClinicCell = @"tagTableViewClinicCell";
int tagTableView = 0;
int tagTableViewClinic = 1;

//static int topInset = 1;
//static int planNotesAndOrderInset = 1;
@implementation ProgressCourseNoteViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  arrayFileNameUpload = [NSMutableArray new];
  _arrayUploadImage = [NSMutableArray new];
  _listImgURL = [NSMutableArray new];
  _listImgNameFile = [NSMutableArray new];
  _arrayAllModule = [NSArray new];
  _dictProgressCourseContent = [NSDictionary new];
  _arrayProgressCourseModule = [NSMutableArray new];
  _arrayDiseasesModule = [NSMutableArray new];
  _arrayListOrder = [NSMutableArray new];
  _arrayListPlanNotes = [NSMutableArray new];
  _arrayDateTime = [NSMutableArray new];
  _arrayEMR = [NSMutableArray new];
  _arrayPlannotesSame = [NSMutableArray new];
  _numberIMG = _maxImage = 0;
  _expandedSections = [NSMutableIndexSet new];
  _arrayDataForEachSection = [NSMutableArray new];
  _arrayAllDateTime = [NSMutableArray new];
  _arrayMedicineNote = [NSMutableArray new];
  _listViewModel = [NSMutableArray new];
  
  _viewEmpty.hidden = YES;
  
  [self.tableView registerNib:[UINib nibWithNibName:@"TagTableViewCell" bundle:nil] forCellReuseIdentifier:tagTableViewCellIdenifier];
  [self.tableView registerNib:[UINib nibWithNibName:@"OrderTableViewCell" bundle:nil] forCellReuseIdentifier:orderTableViewCellIdenifier];
  [self.tableView registerNib:[UINib nibWithNibName:@"ProgressCourseHeaderTableViewCell" bundle:nil] forCellReuseIdentifier:headerTableViewCellIdenifier];
  [self.tableViewClinic registerNib:[UINib nibWithNibName:@"PatientClinicTableViewCell" bundle:nil] forCellReuseIdentifier:tagTableViewClinicCell];
  [self.tableView setTag:tagTableView];
  [self.tableViewClinic setTag:tagTableViewClinic];
  self.tableView.showsVerticalScrollIndicator = NO;
  self.tableView.showsHorizontalScrollIndicator = NO;
  self.tableView.backgroundColor = [PHRUIColor colorProgressCourseTableCellWithAlpha:1.0];
  [self initializePregressCourseNoteView];
  //[self setupNavigationBarTitle:kLocalizedString(kTitleCourseNote) titleIcon:@"Progress Course Note" rightItem:nil];
  
  self.labelHospitalName.text = kLocalizedString(kHospitalName);
  [self requestPatientClinicWithProfileID:PHRAppStatus.currentStandard.profileId];
}

- (void)refreshTableView {
  arrayFileNameUpload = [NSMutableArray new];
  _arrayUploadImage = [NSMutableArray new];
  _listImgURL = [NSMutableArray new];
  _listImgNameFile = [NSMutableArray new];
  _arrayAllModule = [NSArray new];
  _dictProgressCourseContent = [NSDictionary new];
  _arrayProgressCourseModule = [NSMutableArray new];
  _arrayDiseasesModule = [NSMutableArray new];
  _arrayListOrder = [NSMutableArray new];
  _arrayListPlanNotes = [NSMutableArray new];
  _arrayDateTime = [NSMutableArray new];
  _arrayEMR = [NSMutableArray new];
  _arrayPlannotesSame = [NSMutableArray new];
  _numberIMG = _maxImage = 0;
  _expandedSections = [NSMutableIndexSet new];
  _arrayDataForEachSection = [NSMutableArray new];
  _arrayAllDateTime = [NSMutableArray new];
  _arrayMedicineNote = [NSMutableArray new];
  
  [self.tableView reloadData];
  
}

- (void)reloadPatientClinic {
  _listViewModel = [NSMutableArray new];
  [self.tableViewClinic reloadData];
  [self refreshTableView];
  [self.tableViewClinic setHidden:NO];
  [self requestPatientClinicWithProfileID:PHRAppStatus.currentStandard.profileId];
}

- (void)viewWillAppear:(BOOL)animated{
  [super viewWillAppear:animated];
  //[self setImageToBackgroundStandard:self.backgroundImage];
}
- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  if (tableView.tag == 0) {
    
    if (indexPath.row == 0) { // header of section
      return 40.0;
    }
    if(indexPath.section % 2 == 0){
      return UITableViewAutomaticDimension;
    }
  } else {
    return 86.0;
  }
  return UITableViewAutomaticDimension;
}

-(CGFloat)tableView:(UITableView *)tableView estimatedHeightForRowAtIndexPath:(NSIndexPath *)indexPath {
  if (tableView.tag == 0) {
    if (indexPath.row == 0) { // header of section
      return 40.0;
    }
    if(indexPath.section % 2 == 0){
      return 40.0;
    }
  } else {
    return 86.0;
  }
  
  return 75.0;
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  if (tableView.tag == 0 && _arrayAllDateTime.count > 0) {
    return _arrayAllDateTime.count * 2;
  }
  else {
    return 1;
  }
  return 0;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  if (tableView.tag == 0) {
    if (_arrayAllDateTime.count > 0){
      if ([_expandedSections containsIndex:section]) {
        if(section % 2 == 0){
          //NSString *confirmDate = [_arrayAllDateTime objectAtIndex:section];
          NSMutableArray *listPlan = _arrayListPlanNotes[section/2];
          
          NSInteger count = 0;
          count++; // header
          
          // plan notes
          count += listPlan.count;
          
          return count;
          
        } else {
          //NSString *confirmDate = [_arrayAllDateTime objectAtIndex:section];
          int indexOfListOrder = (int)(section / 2);
          if (_arrayListOrder.count > indexOfListOrder) {
            NSMutableArray *listOrder = _arrayListOrder[section/2];
            NSInteger count = 0;
            count++; // header
            
            // order
            count += listOrder.count;
            
            return count;
          }
          return 0;
          
        }
      }
      return 1;
    }
  }
  else {
    return _listViewModel.count;
  }
  return 0;
}
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  if (tableView.tag == 0) {
    if(indexPath.section % 2 == 0){
      if (indexPath.row == 0) {
        ProgressCourseHeaderTableViewCell *tagCell = (ProgressCourseHeaderTableViewCell*) [tableView dequeueReusableCellWithIdentifier:headerTableViewCellIdenifier forIndexPath:indexPath];
        [tagCell setSelectionStyle:UITableViewCellSelectionStyleNone];
        tagCell.labelType.text = kLocalizedString(kPatientRecord);
        tagCell.labelDateTime.text = [[_arrayAllDateTime objectAtIndex:indexPath.section/2] stringByReplacingOccurrencesOfString:@"/" withString:@"-"];
        tagCell.backgroundColor = [UIColor colorWithRed:128.0/255.0 green:185.0/255.0 blue:206.0/255.0 alpha:1.0];
        tagCell.imageType.image = [UIImage imageNamed:@"Icon_Patient_Record"];
        tagCell.imageArrowDown.image = [UIImage imageNamed:@"Icon_white_arrow_right"];
        //            if(((NSMutableArray*)_arrayListPlanNotes[indexPath.section/2]).count > 0){
        //               tagCell.imageArrowDown.image = [UIImage imageNamed:@"Icon_white_arrow_right"];
        //            }
        
        return tagCell;
      }
      
      if (indexPath.row >= 1 && indexPath.row < ((NSMutableArray*)_arrayListPlanNotes[indexPath.section/2]).count + 1) { // tag
        TagTableViewCell *tagCell = (TagTableViewCell*) [tableView dequeueReusableCellWithIdentifier:tagTableViewCellIdenifier forIndexPath:indexPath];
        [tagCell setSelectionStyle:UITableViewCellSelectionStyleNone];
        EMRPlan* emr = (EMRPlan*)((NSMutableArray*)_arrayListPlanNotes[indexPath.section/2])[indexPath.row - 1];
        [tagCell setupCellWithData:emr];
        
        [tagCell setActionOpenTagUrl:^(EMRPlan *emr){
          [self.viewLoading setHidden:NO];
          NSString *download = [[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_EMR_Download"];
          NSMutableURLRequest * mRequest = [[NSMutableURLRequest alloc] initWithURL:[NSURL URLWithString:download]];
          [mRequest setValue:@"ap" forHTTPHeaderField:@"Content-Type"];
          [mRequest setValue:@"1234" forHTTPHeaderField:KEY_Token];
          [mRequest setValue:@"2" forHTTPHeaderField:@"TRANSFER_TYPE"];
          [mRequest setValue:_hospitalCode forHTTPHeaderField:@"HOSP_CODE"];
          [mRequest setValue:_patientCode forHTTPHeaderField:@"PATIENT_CODE"];
          [mRequest setValue:emr.tagContent forHTTPHeaderField:@"filename"];
          
          if (emr.tagType == EMRTagTypePdf) {
           // [self showWebView:mRequest];
            WebviewController *webViewController = [[WebviewController alloc] initWithNibName:NSStringFromClass([WebviewController class]) bundle:nil];
            webViewController.mRequest = mRequest;
            self.openWebViewController(webViewController);
            [self.viewLoading setHidden:YES];
          }
          else if (emr.tagType == EMRTagTypePhoto) {
            if (isClicked) {
              return;
            }
            isClicked = YES;
            AFImageResponseSerializer *serializer = [[AFImageResponseSerializer alloc] init];
            serializer.acceptableContentTypes = [serializer.acceptableContentTypes setByAddingObject:@"image/pjpeg"];
            
            AFHTTPRequestOperation *posterOperation = [[AFHTTPRequestOperation alloc] initWithRequest:mRequest];
            posterOperation.responseSerializer = serializer;
            
            [posterOperation setCompletionBlockWithSuccess:^(AFHTTPRequestOperation *operation, id responseObject) {
              isClicked = NO;
              [self.viewLoading setHidden:YES];
              NSLog(@"Response: %@", responseObject);
              self.openShowImageViewController(responseObject);
             // [self showImage:[[UIImageView alloc] initWithImage:responseObject]];
              
            } failure:^(AFHTTPRequestOperation *operation, NSError *error) {
              isClicked = NO;
              [self.viewLoading setHidden:YES];
              NSLog(@"Image request failed with error: %@", error);
            }];
            [[NSOperationQueue mainQueue] addOperation:posterOperation];
            [posterOperation start];
          }
        }];
        
        if(indexPath.row % 2 == 0 && indexPath.row > 1){
          tagCell.viewKey.backgroundColor = [UIColor colorWithRed:240.0/255.0 green:240.0/255.0 blue:240.0/255.0 alpha:1.0];
        }
        
        return tagCell;
      }
      
      
    } else {
      
      if (indexPath.row == 0) {
        ProgressCourseHeaderTableViewCell *tagCell = (ProgressCourseHeaderTableViewCell*) [tableView dequeueReusableCellWithIdentifier:headerTableViewCellIdenifier forIndexPath:indexPath];
        [tagCell setSelectionStyle:UITableViewCellSelectionStyleNone];
        tagCell.labelType.text = kLocalizedString(kOrderList);
        tagCell.labelDateTime.text = [[_arrayAllDateTime objectAtIndex:indexPath.section/2] stringByReplacingOccurrencesOfString:@"/"
                                                                                                                      withString:@"-"];
        tagCell.backgroundColor = [UIColor colorWithRed:91.0/255.0 green:156.0/255.0 blue:180.0/255.0 alpha:1.0];
        tagCell.imageType.image = [UIImage imageNamed:@"Icon_Order_List"];
        tagCell.imageArrowDown.image = [UIImage imageNamed:@"Icon_white_arrow_right"];
        return tagCell;
      }
      
      
      OrderTableViewCell *orderCell = (OrderTableViewCell*) [tableView dequeueReusableCellWithIdentifier:orderTableViewCellIdenifier forIndexPath:indexPath];
      
      [orderCell setSelectionStyle:UITableViewCellSelectionStyleNone];
      OrderModel *obj = (OrderModel*)((NSMutableArray*)_arrayListOrder[indexPath.section/2])[indexPath.row - 1];
      
      orderCell.labelInputGubunName.text = obj.InputGubunName;
      orderCell.labelHangmogName.text = obj.HangmogName;
      orderCell.labelOrderGubunName.text = obj.OrderGubunName;
      orderCell.labelContent.text = obj.Content;
      if ([obj.GubunBass isEqualToString:KEY_OC] || [obj.GubunBass isEqualToString:KEY_OD]) {
        orderCell.labelDosage.text = [self getDosageWithHangmogCode:obj.HangmogCode andNeawonKey:obj.NaewonKey];
      } else {
        orderCell.labelDosage.text = @"";
      }
      
      if(indexPath.row % 2 == 0 && indexPath.row > 1) {
        orderCell.viewBorder.backgroundColor = [UIColor colorWithRed:240.0/255.0 green:240.0/255.0 blue:240.0/255.0 alpha:1.0];
      } else {
        orderCell.viewBorder.backgroundColor = [UIColor colorWithRed:255.0/255.0 green:255.0/255.0 blue:255.0/255.0 alpha:1.0];
      }
      
      return orderCell;
    }
  } else {
    PatientClinicTableViewCell *cell = (PatientClinicTableViewCell*) [tableView dequeueReusableCellWithIdentifier:tagTableViewClinicCell forIndexPath:indexPath];
    [cell setViewModelForCell:_listViewModel[indexPath.row]];
    return cell;
  }
  return nil;
}


- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  if (tableView.tag == 0) {
    if (!indexPath.row) {
      // only first row toggles exapand/collapse
      ProgressCourseHeaderTableViewCell *cell = [self.tableView cellForRowAtIndexPath:indexPath];
      [tableView deselectRowAtIndexPath:indexPath animated:YES];
      
      NSInteger section = indexPath.section;
      BOOL currentlyExpanded = [_expandedSections containsIndex:section];
      NSInteger rows;
      
      NSMutableArray *tmpArray = [NSMutableArray array];
      
      if (currentlyExpanded) {
        rows = [self tableView:tableView numberOfRowsInSection:section];
        cell.imageArrowDown.image = [UIImage imageNamed:@"Icon_white_arrow_right"];
        [_expandedSections removeIndex:section];
      }
      else {
        [_expandedSections addIndex:section];
        cell.imageArrowDown.image = [UIImage imageNamed:@"Icon_white_arrow"];
        rows = [self tableView:tableView numberOfRowsInSection:section];
      }
      
      for (int i = 1; i < rows; i++) {
        NSIndexPath *tmpIndexPath = [NSIndexPath indexPathForRow:i
                                                       inSection:section];
        [tmpArray addObject:tmpIndexPath];
      }
      
      //UITableViewCell *cell = [tableView cellForRowAtIndexPath:indexPath];
      
      if (currentlyExpanded) {
        _isShow = YES;
        [tableView deleteRowsAtIndexPaths:tmpArray
                         withRowAnimation:UITableViewRowAnimationTop];
        
        //cell.accessoryView = [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeDown];
      }
      else {
        _isShow = NO;
        
        [tableView insertRowsAtIndexPaths:tmpArray
                         withRowAnimation:UITableViewRowAnimationTop];
        //cell.accessoryView =  [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeUp];
      }
    }
  } else {
    
    self.tableViewClinic.hidden = YES;
    
    PatientClinicViewModel *patientModel = [_listViewModel objectAtIndex:indexPath.row];
    
    [self getProgressCourse:patientModel.model.hospName hospitalCode:patientModel.model.hospCode andPatientCode:patientModel.model.patientCode];
  }
}

#pragma mark - Initialize First Run

- (void)initializePregressCourseNoteView {
  self.viewLoading.layer.cornerRadius = 6;
  
  [self.noteProgressCourse setTextColor:PHR_COLOR_GRAY];
  [self.dateProgressCourse setDatetime:[NSDate date]];
  [self.btnUploadFile setTitle:kLocalizedString(kUploadFile) forState:UIControlStateNormal];
  
  self.noteProgressCourse.delegate = self;
  [self.noteProgressCourse setText:kLocalizedString(kNote)];
  
  [self.textFieldStatus setTextColor:PHR_COLOR_GRAY];
  [self.txtHospitalProgress setTextColor:PHR_COLOR_GRAY];
  
  [self.lbTextEvidenceUploaded setTextColor:PHR_COLOR_GRAY];
  [self.lbTextEvidenceUploaded setText:kLocalizedString(kTitleUpload)];
  
  [self.textFieldStatus setPlaceholder:kLocalizedString(kStatus)];
  [self.txtHospitalProgress setPlaceholder:kLocalizedString(kHospital)];
  
  [self.viewProgressUploadFile setDelegate:self];
  [self resetView];
}

- (void)showOrHideLoading:(BOOL)isShowed {
  if (isShowed) {
    [self.viewLoading setHidden:NO];
  } else {
    [self.viewLoading setHidden:YES];
  }
}

#pragma mark - Override method

- (void)createNewProgressCourse {
  ProgressCourse *objProgress = [[ProgressCourse alloc] init];
  NSString *record_Url = PHR_STR_NULL;
  
  if (_listImgURL.count > 0) {
    record_Url = [_listImgURL firstObject];
    for (int i = 1; i < _listImgURL.count; i++) {
      NSString *str = [_listImgURL objectAtIndex:i];
      NSString *addStr = [NSString stringWithFormat:@"%@%@", PHR_STR_DETACHMENT,str];
      record_Url  = [record_Url stringByAppendingString:addStr];
    }
  }
  
  objProgress.datetime_record     = [self.dateProgressCourse stringDateParam];
  objProgress.hospital            = self.txtHospitalProgress.text;
  objProgress.medical_record_url  = record_Url;
  objProgress.status              = self.textFieldStatus.text;
  objProgress.note                = self.noteProgressCourse.text;
  
  __weak __typeof(self) weakSelf = self;
  
  [[PHRClient instance] requestAddNewProgressCourseWithObjNote:objProgress andCompleted:^(id result) {
    [PHRAppDelegate hideLoading];
    [weakSelf backToPopView];
  } error:^(NSString *error) {
    [PHRAppDelegate hideLoading];
    [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
  }];
}

- (void)resetView {
  [self.dateProgressCourse setDatetime:[NSDate date]];
  [self.txtHospitalProgress setText:PHR_STR_NULL];
  [self.textFieldStatus setText:PHR_STR_NULL];
  [self.noteProgressCourse setText:PHR_STR_NULL];
}

- (void)backToPopView {
  [self.navigationController popViewControllerAnimated:YES];
}

#pragma mark - Parse data
- (void)getProgressCourse:(NSString*)hospitalName hospitalCode:(NSString*)hospitalCode andPatientCode:(NSString*)patientCode {
  
  [self refreshTableView];
  [self showOrHideLoading:YES];
  self.labelHospitalName.textColor = [UIColor colorWithRed:15.0/255.0 green:171.0/255.0 blue:154.0/255.0 alpha:1.0];
  self.labelHospitalName.text = hospitalName;
  if (hospitalCode && patientCode && ![hospitalCode isEmpty] && ![patientCode isEmpty]) {
    _hospitalCode = hospitalCode;
    _patientCode = patientCode;
    [self getAndParseData:hospitalCode andPatientCode:patientCode];
  }
}

//- (void)getLocalData{
//    [self showOrHideLoading:YES];
//    NSString* plistPath = [[NSBundle mainBundle] pathForResource:@"EMR_000002005_323" ofType:@"txt"];
//    NSString *xmlString = [[NSString alloc] initWithContentsOfFile:plistPath encoding:NSUTF8StringEncoding error:NULL];
//
//    _xmlProgressCourseContent  = [self replaceWrongXMLData:xmlString];
//    _dictProgressCourseContent = [NSDictionary dictionaryWithXMLString:_xmlProgressCourseContent];
//    _arrayAllModule = [_dictProgressCourseContent arrayValueForKeyPath:KEYPath_GetMmlModuleItem];
//    _arrayProgressCourseModule = [self getProgressCourseModule:_arrayAllModule];
//
//    _arrayListOrder = [self getProgressCourseModuleOrderList:_arrayProgressCourseModule];
//    _arrayListPlanNotes = [self getProgressCourseModulePlaneNotes:_arrayProgressCourseModule];
//    _arrayDateTime = [self getDateTimeOfProgressCourse];
//
//    //[self.tableView reloadData];
//
//    // REQUEST FOR MEDICINE_NOTE
//    [[PHRClient instance] requestGetListMedicineNoteForPatient:@"000002005" hospCode:@"323" completed:^(id responseObj) {
//        if (responseObj && [responseObj valueForKey:@"content"]) {
//            //NSLog(@"responseObj-content: %@",[responseObj valueForKey:KEY_Content]);
//            NSArray *arrayMedicineList = [[responseObj valueForKey:KEY_Content] valueForKey:KEY_Medicine_List];
//            if (arrayMedicineList.count > 0) {
//                for (NSDictionary *dict in arrayMedicineList) {
//                    MedicineNoteModel *model = [[MedicineNoteModel alloc] initWithDictionary:dict error:nil];
//                    [self.arrayMedicineNote addObject:model];
//                }
//            }
//            [self.tableView reloadData];
//        }
//        [self showOrHideLoading:NO];
//    } error:^(NSString *error) {
//        [self showOrHideLoading:NO];
//        [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
//    }];
//}

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
        _xmlProgressCourseContent  = [ParseDataProgressCourse replaceWrongXMLData:xmlString];
        if (response.content[KEY_EMR_Tag]) {
          NSArray *arrayResultEMR =  response.content[KEY_EMR_Tag];
          if (arrayResultEMR != nil && arrayResultEMR != (id)[NSNull null] && [arrayResultEMR count] > 0) {
            for (int i = 0 ;i < arrayResultEMR.count; i++) {
              NSDictionary *dict = [arrayResultEMR objectAtIndex:i];
              
              [_arrayEMR addObject:[EMRTag initWithObj:dict]];
              
            }
          }
        }
        
        _dictProgressCourseContent = [NSDictionary dictionaryWithXMLString:_xmlProgressCourseContent];
        _arrayAllModule = [_dictProgressCourseContent arrayValueForKeyPath:KEYPath_GetMmlModuleItem];
        NSArray *arrayModule = [ParseDataProgressCourse getProgressCourseModule:_arrayAllModule];
        _arrayProgressCourseModule = [arrayModule objectAtIndex:0];
        
        _arrayListOrder = [ParseDataProgressCourse getProgressCourseModuleOrderList:_arrayProgressCourseModule];
        _arrayListPlanNotes = [self getProgressCourseModulePlaneNotes:_arrayProgressCourseModule];
        _arrayDateTime = [self getDateTimeOfProgressCourse];
        
        //Diseases
        _arrayDiseasesModule = [arrayModule objectAtIndex:1];
        NSArray *arrayDiseases = [self getDiseasesList:_arrayDiseasesModule];
        self.didFinishGettingDiseasesList(arrayDiseases);
        
        // REQUEST FOR MEDICINE_NOTE
        NSLog(@"Patient %@ - %@",patientCode,hospitalCode);
        [[PHRClient instance] requestGetListMedicineNoteForPatient:patientCode hospCode:hospitalCode completed:^(id responseObj) {
          if (responseObj) {
            if (![responseObj[KEY_Content] isKindOfClass:[NSNull class]]) {
              NSArray *arrayMedicineList = (responseObj[KEY_Content])[KEY_Medicine_List];
              if (arrayMedicineList && arrayMedicineList.count > 0) {
                for (NSDictionary *dict in arrayMedicineList) {
                  MedicineNoteModel *model = [[MedicineNoteModel alloc] initWithDictionary:dict error:nil];
                  [self.arrayMedicineNote addObject:model];
                }
              }
            }
          }
          [self.tableView reloadData];
          [self showOrHideLoading:NO];
        } error:^(NSString *error) {
          [self showOrHideLoading:NO];
          [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
        }];
      } else {
        [self showOrHideLoading:NO];
      }
    } else {
      [self showOrHideLoading:NO];
    }
  }];
}

- (NSArray*)getDiseasesList:(NSArray*)inputArray {
  NSMutableArray *arrayDiseases = [[NSMutableArray alloc] init];
  for (NSDictionary *dict in inputArray) {
    NSDictionary *dictContent = [dict valueForKeyPath:KEYPath_GetMmlContentRegisteredDiagnosis];
    if (dictContent) {
      NSDictionary *dictRegisteredDiagnosis = [dictContent valueForKey:@"RegisteredDiagnosisModule"];
      if (dictRegisteredDiagnosis) {
        DiseasesModel *model = [[DiseasesModel alloc] init];
        model.disease_name = [dictRegisteredDiagnosis valueForKeyPath:@"diagnosis.__text"];
        model.start_date = [dictRegisteredDiagnosis valueForKey:@"startDate"];
        model.end_date = [dictRegisteredDiagnosis valueForKey:@"endDate"];
        model.datetime_record = [dictRegisteredDiagnosis valueForKey:@"firstEncounterDate"];
        model.hospital = self.labelHospitalName.text;
        model.outcome = [dictRegisteredDiagnosis valueForKeyPath:@"outcome.__text"];
        [arrayDiseases addObject:model];
      }
    }
  }
  return arrayDiseases;
}


- (NSMutableArray*)getProgressCourseModulePlaneNotes:(NSMutableArray*)inputArray {
  NSMutableArray* result = [NSMutableArray new];
  NSMutableArray* arrayTempAllTime = [NSMutableArray new];
  NSMutableArray* sortedResult = [NSMutableArray new];
  for (NSDictionary *dict in inputArray) {
    NSMutableArray *arrayListPlans = [NSMutableArray new];
    NSString *confirmDate = [dict valueForKeyPath:KEYPath_GetMmlConfirmDate];
    [arrayTempAllTime addObject:confirmDate];
    NSArray *arrayProblemItem = [dict valueForKeyPath:KEYPath_GetMmlProblemItem];
    if (arrayProblemItem.count > 0) {
      for (NSObject *problemItem in arrayProblemItem) {
        if ([problemItem isKindOfClass:[NSDictionary class]]) {
          id planNotes = [problemItem valueForKeyPath:KEYPath_GetMmlPlanNotes];
          id assessmentItem = [problemItem valueForKeyPath:KEYPath_GetMmlAssessmentItem];
          // id subjectItem = [problemItem valueForKeyPath:KEYPath_GetMmlSubjectiveItem];
          id objectiveItem = [problemItem valueForKeyPath:KEYPath_GetMmlObjectiveItem];
          id subjectiveExpression = [problemItem valueForKeyPath:KEYPath_GetMmlSubjectiveItem_eventExpression];
          
          
          NSMutableDictionary *arrayItems = [[NSMutableDictionary alloc] init];
          if (planNotes && [planNotes isKindOfClass:[NSString class]]) {
            //if ([problemItem a])
            id planNotesPermission = [problemItem valueForKeyPath:KEYPath_GetMmlPlanNotesPermission];
            if (planNotesPermission && [planNotesPermission isKindOfClass:[NSString class]]) {
              [arrayItems setObject:(NSString*)planNotes forKey:planNotesPermission];
            } else {
              [arrayItems setObject:(NSString*)planNotes forKey:@"1"];
            }
          }
          
          if (assessmentItem && [assessmentItem isKindOfClass:[NSDictionary class]]) {
            id assesmentItemText = [problemItem valueForKeyPath:KEYPath_GetMmlAssessmentItemText];
            id assessmentItemPermission = [problemItem valueForKeyPath:KEYPath_GetMmlAssessmentItemPermission];
            if (assessmentItemPermission && [assessmentItemPermission isKindOfClass:[NSString class]] && assesmentItemText && [assesmentItemText isKindOfClass:[NSString class]]) {
              [arrayItems setObject:(NSString*)assesmentItemText forKey:assessmentItemPermission];
            } else {
              [arrayItems setObject:(NSString*)assesmentItemText forKey:@"1"];
            }
          } else if (assessmentItem && [assessmentItem isKindOfClass:[NSString class]]){
            [arrayItems setObject:(NSString*)assessmentItem forKey:@"1"];
          }
          
          if (subjectiveExpression && [subjectiveExpression isKindOfClass:[NSString class]]) {
            id subjectItemPermission = [problemItem valueForKeyPath:KEYPath_GetMmlSubjectiveItemPermission];
            if (subjectItemPermission && [subjectItemPermission isKindOfClass:[NSString class]]) {
              [arrayItems setObject:(NSString*)subjectiveExpression forKey:subjectItemPermission];
            } else {
              [arrayItems setObject:(NSString*)subjectiveExpression forKey:@"1"];
            }
          }
          
          if (objectiveItem && [objectiveItem isKindOfClass:[NSString class]]) {
            id objectiveItemPermission = [problemItem valueForKeyPath:KEYPath_GetMmlObjectiveItemPermission];
            if (objectiveItemPermission && [objectiveItemPermission isKindOfClass:[NSString class]]) {
              [arrayItems setObject:(NSString*)objectiveItem forKey:objectiveItemPermission];
            } else {
              [arrayItems setObject:(NSString*)objectiveItem forKey:@"1"];
            }
          }
          
          for (NSString *key in [arrayItems allKeys]) {
            EMRPlan *plan = [[EMRPlan alloc] initWithTag:[arrayItems objectForKey:key] permission:key andArray:_arrayEMR];
            plan.confirmDate = confirmDate;
            [arrayListPlans addObject:plan];
          }
          
        } else if ([problemItem isKindOfClass:[NSArray class]]){
          NSArray *arr = (NSArray*)problemItem;
          for (NSObject *problemItem in arr) {
            NSString *planNotes = [problemItem valueForKeyPath:MML_planNotes];
            if (planNotes && [planNotes isKindOfClass:[NSString class]]){
              EMRPlan *plan = [EMRPlan new];
              plan.tagName = planNotes;
              plan.confirmDate = confirmDate;
              [arrayListPlans addObject:plan];
            }
          }
        }
      }
    }
    [result addObject:arrayListPlans];
  }
  if (arrayTempAllTime.count == 0) {
    return sortedResult;
  }
  NSMutableArray *p = [NSMutableArray arrayWithCapacity:arrayTempAllTime.count];
  for (NSUInteger i = 0 ; i != arrayTempAllTime.count ; i++) {
    [p addObject:[NSNumber numberWithInteger:i]];
  }
  [p sortWithOptions:0 usingComparator:^NSComparisonResult(NSString *obj1, NSString *obj2){
    NSDate *date1 = [UIUtils dateFromString:[arrayTempAllTime objectAtIndex:[obj1 intValue]] withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    NSDate *date2 = [UIUtils dateFromString:[arrayTempAllTime objectAtIndex:[obj2 intValue]] withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    return [date2 compare:date1];
  }];
  
  [p enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
    NSUInteger pos = [obj intValue];
    [sortedResult addObject:[result objectAtIndex:pos]];
    [_arrayAllDateTime addObject:[arrayTempAllTime objectAtIndex:pos]];
  }];
  return sortedResult;
}

- (NSMutableArray*)getDateTimeOfProgressCourse{
  NSMutableArray* result = _arrayDateTime;
  for (NSString *obj in _arrayAllDateTime) {
    if (result.count > 0) {
      BOOL isAdd = YES;
      for (NSString *dateTime in result) {
        if ([dateTime isEqualToString:obj]) {
          isAdd = NO;
        }
      }
      if (isAdd) {
        [result addObject:obj];
      }
    }
    else {
      [result addObject:obj];
    }
  }
  
  return result;
}

- (NSString*)getDosageWithHangmogCode:(NSString*)hangmogCode andNeawonKey:(NSString*)neawonKey {
  NSString* result = @"";
  for (MedicineNoteModel *obj in self.arrayMedicineNote) {
    if ([obj.hangmog_code isEqualToString:hangmogCode] && [obj.neawon_key isEqualToString:neawonKey]) {
      result = obj.dosage;
    }
  }
  return result;
}

#pragma mark - Upload File
- (IBAction)pressUploadFile:(id)sender {
  if (arrayFileNameUpload.count == PHR_FILE_UPLOAD_MAX) {
    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
    return;
  }
  else {
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
    picker.maximumNumberOfSelectionPhoto = PHR_FILE_UPLOAD_MAX - arrayFileNameUpload.count;
    
    [self presentViewController:picker animated:YES completion:^{
      //
    }];
  }
}

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
        [weakSelf createNewProgressCourse];
      }
    }
  }];
}

#pragma mark - UzysAssetsPickerControllerDelegate Methods

- (void)uzysAssetsPickerController:(UzysAssetsPickerController *)picker didFinishPickingAssets:(NSArray *)assets {
  for (ALAsset *objAlasset in assets) {
    NSURL *originalFileName = [[objAlasset defaultRepresentation] url];
    [arrayFileNameUpload addObject:originalFileName];
    
    NSString *fileName = [[objAlasset defaultRepresentation] filename];
    [_listImgNameFile addObject:fileName];
    
    if([[objAlasset valueForProperty:@"ALAssetPropertyType"] isEqualToString:@"ALAssetTypePhoto"])
    {
      [assets enumerateObjectsUsingBlock:^(id obj, NSUInteger idx, BOOL *stop) {
        ALAsset *representation = obj;
        UIImage *img = [UIImage imageWithCGImage:representation.defaultRepresentation.fullResolutionImage
                                           scale:representation.defaultRepresentation.scale
                                     orientation:(UIImageOrientation)representation.defaultRepresentation.orientation];
        if (img) {
          [_arrayUploadImage addObject:img];
          _maxImage += 1;
        }
        *stop = YES;
      }];
    }
  }
  
  if (arrayFileNameUpload.count > 0) {
    [self.viewProgressUploadFile addViewNameFileUploadInParentView:arrayFileNameUpload andListFileName:_listImgNameFile];
  }
}

- (void)uzysAssetsPickerControllerDidExceedMaximumNumberOfSelection:(UzysAssetsPickerController *)picker {
  [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMaxUploadFile)];
}

#pragma PHRUploadFile Delegate

- (void)deleteFileUpload:(UIButton *)btn {
  if (_maxImage > 0) {
    _maxImage -= 1;
  }
  if (_listImgNameFile.count > 0) {
    [_listImgNameFile removeObjectAtIndex:btn.tag];
  }
  if (arrayFileNameUpload.count > 0) {
    [arrayFileNameUpload removeObjectAtIndex:btn.tag];
  }
  if (_arrayUploadImage.count > 0) {
    [_arrayUploadImage removeObjectAtIndex:btn.tag];
  }
  if (_listImgURL.count > 0) {
    [_listImgURL removeObjectAtIndex:btn.tag];
  }
}

#pragma mark - UITextField Delegate

- (BOOL)textFieldShouldReturn:(UITextField *)textField {
  [textField resignFirstResponder];
  return YES;
}

#pragma mark - UITextView Delegate

- (void)textViewDidBeginEditing:(UITextView *)textView {
  if (textView == self.noteProgressCourse && [textView.text isEqualToString:kLocalizedString(kNote)]) {
    textView.text = PHR_STR_NULL;
    textView.textColor = PHR_COLOR_GRAY;
  }
  [textView becomeFirstResponder];
}

- (void)textViewDidEndEditing:(UITextView *)textView {
  if (textView == self.noteProgressCourse && [textView.text isEqualToString:@""]) {
    textView.text = kLocalizedString(kNote);
    textView.textColor = [UIColor lightGrayColor];
  }
  [textView resignFirstResponder];
}

# pragma mark - Choose clinic account
- (void)requestPatientClinicWithProfileID:(NSString *)profileID {
  [self.viewLoading setHidden:NO];
  [BaseNetworking configureNetworkingWithHost:[[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_Clinic"]];
  NSString *URL = [NSString stringWithFormat:API_PHR03, profileID, PHRAppStatus.token];
  [[[BaseNetworking sharedInstance] fetchRequest:URL params:nil] continueWithBlock:^id _Nullable(BFTask * _Nonnull t) {
    [self.viewLoading setHidden:YES];
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
      if (!_listViewModel) {
        _listViewModel = [[NSMutableArray alloc] init];
      }
      [_listViewModel addObject:viewModel];
    }
    if (_listViewModel.count == 0) {
   //   self.labelHospitalName.text = kLocalizedString(@"You don't have any clinic account.");
      _viewEmpty.hidden = NO;
    }else{
      _viewEmpty.hidden = YES;
    }
    [self.tableViewClinic reloadData];
  }
}


@end
