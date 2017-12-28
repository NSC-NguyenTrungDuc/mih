//
//  AddNewPresciptionViewController.m
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddNewPresciptionViewController.h"
#import "AddNewDrugTableViewCell.h"
#import "AddRemiderTableViewCell.h"
#import "AddNewDrugFooter.h"
#import "AddNewDrugHeader.h"
#import "AddNewRemiderFooter.h"
#import "AddNewRemiderHeader.h"
#import "AddNewDrugViewController.h"
#import "IQActionSheetPickerView.h"
#import "AddNewStandardDrugViewController.h"
#import "AddNewReminderViewController.h"

#define NUMBER_OF_SECTION 2
#define NUMBER_OF_REMIDER_NO_EXPANT 1
#define NUMBER_OF_ADD_DRUG 5

@interface AddNewPresciptionViewController ()<IQActionSheetPickerViewDelegate>{
  int pageNumber;
  BOOL isFirstCome;
  bool isExpant;
}

@end


@implementation AddNewPresciptionViewController{
  
}

- (void)viewDidLoad {
  [super viewDidLoad];
  [self.tableContent setDelegate:self];
  [self.tableContent setDataSource:self];
  [self initGradient];
  [self initializeAddNewPresciption];
  
  isExpant = YES;
  isFirstCome = YES;
  pageNumber = 1;
  
  self.arrayDrug = [[NSMutableArray alloc] init];
  
  NSString *prescriptionId = self.data.prescription_id;
  self.txtPrescriptionName.text = self.data.prescription_name;
  self.lblPrescriptionName.font = [FontUtils aileronRegularWithSize:13.0];
  self.lblPrescriptionName.text = kLocalizedString(kPrescriptionName);
  [self.txtPrescriptionName setEnabled:NO];
  
  //  [self.dateTimeView updateTime:[UIUtils dateFromString:self.data.datetime_record withFormat:PHR_SERVER_DATE_TIME_FORMAT] shortFormat:NO];
  [self.dateTimeView updateTimeFromString:self.data.datetime_record];
  [self.dateTimeView setClickEnable:NO];
  
  // Get notification list with ID
  self.arrayNotification = [[NSMutableArray alloc]init];
  NSMutableArray *allNotifications = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] scheduledLocalNotifications]];
  for (UILocalNotification *noti in allNotifications) {
    NSString *presID = [noti.userInfo valueForKey:@"ID"];
    
    DLog(@"Notifi Infoxxx %@",noti.userInfo);
    
    if(presID !=nil && [[NSString stringWithFormat:@"%@",presID] containsString:[NSString stringWithFormat:@"PresKey%@",prescriptionId]]){
      [self.arrayNotification addObject:noti];
    }
  }
  [self initData];
}

- (void)viewWillAppear:(BOOL)animated{
  [super viewWillAppear:animated];
  [self setImageToBackgroundStandard:self.imageBackground];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(actionExpant:) name:@"actionExpant" object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(actionAddNewDrug:) name:@"actionAddNewDrug" object:nil];
}

- (void)initGradient {
  UIColor *colorOne = [UIColor colorWithRed:1.0f green:1.0f blue:1.0f alpha:0.0f];
  UIColor *colorTwo = [UIColor colorWithRed:1.0f green:1.0f blue:1.0f alpha:0.4f];
  UIColor *colorThree = [UIColor colorWithRed:1.0f green:1.0f blue:1.0f alpha:1.0f];
  NSArray *colors = [NSArray arrayWithObjects:(id)colorOne.CGColor, colorTwo.CGColor,colorThree.CGColor, nil];
  NSNumber *stopOne = [NSNumber numberWithFloat:0.2];
  NSNumber *stopTwo = [NSNumber numberWithFloat:0.3];
  NSNumber *stopThree = [NSNumber numberWithFloat:0.5];
  NSArray *locations = [NSArray arrayWithObjects:stopOne, stopTwo,stopThree, nil];
  
  CAGradientLayer *gradientLayer = [CAGradientLayer layer];
  gradientLayer.frame = CGRectMake(self.imageBackground.bounds.origin.x, self.imageBackground.bounds.origin.y, [UIScreen mainScreen].bounds.size.width, self.imageBackground.bounds.size.height);
  gradientLayer.colors = colors;
  gradientLayer.locations = locations;
  if ([self.imageBackground.layer sublayers].count > 0) {
    [self.imageBackground.layer replaceSublayer:[self.imageBackground.layer sublayers][0] with:gradientLayer];
  }
  else{
    [self.imageBackground.layer insertSublayer:gradientLayer atIndex:0];
  }
}

- (void)viewWillDisappear:(BOOL)animated{
  [super viewWillDisappear:animated];
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)initializeAddNewPresciption {
  if (self.type == PHRGroupTypeDiseaes) {
    [self setupNavigationBarTitle:kLocalizedString(kTitleDiseases) titleIcon:@"icon_title_injuries" rightItem:[self itemRightStandardKey:kAdd]];
    
  } else {
    [self setupNavigationBarTitle:kLocalizedString(kTitleMedicine) iconLeft:nil iconRight:nil iconMiddle:@"Medicine Note" isDismissView:false colorLeft:[PHR_COLOR_MEDICINE_OVERLAY colorWithAlphaComponent:0.6]colorRight:[PHR_COLOR_MEDICINE_MAIN_COLOR colorWithAlphaComponent:0.6]];
    //        [self setupNavigationBarTitle:kLocalizedString(kTitleMedicine) titleIcon:@"Medicine Note" rightItem:nil];
    
  }
  
  self.navBar.buttonRight.hidden = YES;
  
  [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddRemiderTableViewCell class]) bundle:nil] forCellReuseIdentifier:@"add_remider_cell"];
  [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewRemiderHeader class]) bundle:nil] forCellReuseIdentifier:@"add_remider_header_cell"];
  [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewRemiderFooter class]) bundle:nil] forCellReuseIdentifier:@"add_remider_footer_cell"];
  
  [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewDrugTableViewCell class]) bundle:nil] forCellReuseIdentifier:@"add_new_drug_cell"];
  [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewDrugHeader class]) bundle:nil] forCellReuseIdentifier:@"add_new_drug_header_cell"];
  [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewDrugFooter class]) bundle:nil] forCellReuseIdentifier:@"add_new_drug_footer_cell"];
  
  self.tableContent.showsHorizontalScrollIndicator = NO;
  self.tableContent.showsVerticalScrollIndicator = NO;
  
}
- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  return NUMBER_OF_SECTION;
}


- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  if(section == PHRMedicineAddRemider){
    if(!isExpant){
      return NUMBER_OF_REMIDER_NO_EXPANT;
    }
    return self.arrayNotification.count + 1;
  }else{
    return self.arrayDrug.count+1;
  }
  
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  if(indexPath.section == PHRMedicineAddRemider) {
    
    if(isExpant) {
      if(indexPath.row == 0) {
        AddNewRemiderHeader *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_remider_header_cell" forIndexPath:indexPath];
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
      } else if(indexPath.row == self.arrayNotification.count+1) {
        
        AddNewRemiderFooter *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_remider_footer_cell" forIndexPath:indexPath];
        if (!cell) {
          cell = [[AddNewRemiderFooter alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_remider_footer_cell"];
        }
        cell.selectionStyle = UITableViewCellSelectionStyleNone;
        return cell;
        
      } else {
        AddRemiderTableViewCell *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_remider_cell" forIndexPath:indexPath];
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
          [self.tableContent reloadData];
        }];
        
        return cell;
      }
      
    } else {
      AddNewRemiderHeader *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_remider_header_cell" forIndexPath:indexPath];
      if (!cell) {
        cell = [[AddNewRemiderHeader alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_remider_header_cell"];
      }
      
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      
      return cell;
    }
  } else {
    if(indexPath.row == 0){
      AddNewDrugHeader *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_new_drug_header_cell" forIndexPath:indexPath];
      cell.isShowAdd = NO;
      if (!cell) {
        cell = [[AddNewDrugHeader alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_new_drug_header_cell"];
      }
      
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      
      return cell;
      
    } else {
      AddNewDrugTableViewCell *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_new_drug_cell" forIndexPath:indexPath];
      if (!cell) {
        cell = [[AddNewDrugTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_new_drug_cell"];
      }
      
      DrugNote  *obj = ([self.arrayDrug objectAtIndex:indexPath.row-1]);
      
      cell.lblDrugName.text = obj.drug_name;
      cell.lblRemider.text = obj.note;
      DLog(@"Method %@",obj.method);
      if([obj.method isEqualToString:@"0C"]){
        
        cell.imgDrugIcon.image = [UIImage imageNamed:@"Icon_drink_drug_disabled"];
        
      }else{
        cell.imgDrugIcon.image = [UIImage imageNamed:@"Icon_external_drug_disabled"];
      }
      
      cell.selectionStyle = UITableViewCellSelectionStyleNone;
      return cell;
    }
    
  }
  return nil;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  return 50.0;
}

- (void)actionExpant:(NSNotification *)notification {
  if(!isExpant){
    isExpant = YES;
    [self.tableContent reloadData];
    
  } else {
    isExpant = NO;
    [self.tableContent reloadData];
  }
}

- (void)actionAddNewDrug:(NSNotification *)notification {
  AddNewDrugViewController *controller = [[AddNewDrugViewController alloc] initWithNibName:NSStringFromClass([AddNewDrugViewController class]) bundle:nil];
  controller.type = self.type;
  
  
  [self.navigationController pushViewController:controller animated:YES];
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
  
  NSString *keyNotification = [NSString stringWithFormat:@"%@AndPresKey%@",[UIUtils stringDate:localNotification.fireDate withFormat:PHR_CLIENT_TIME_FORMAT_FULL],[NSString stringWithFormat:@"%@",self.data.prescription_id]];
  NSDate *keyEndDate = [date dateByAddingTimeInterval:addingDate * 86400];
  NSMutableDictionary *userInfo = [NSMutableDictionary dictionaryWithObject:keyNotification forKey:@"ID"];
  [userInfo setObject:keyEndDate forKey:PHR_REMIND_END_DATE];
  localNotification.userInfo = userInfo;
  
  //localNotification.applicationIconBadgeNumber = [[UIApplication sharedApplication] applicationIconBadgeNumber] + 1;
  [[UIApplication sharedApplication] scheduleLocalNotification:localNotification];
  [self.arrayNotification addObject:localNotification];
  
  [self.tableContent reloadData];
}

- (void)initData {
  for (int i = 0; i < self.data.listOrderModel.count; i++) {
    OrderModel *orderModel = [self.data.listOrderModel objectAtIndex:i];
    if (![orderModel.GubunBass isEqualToString:@"0C"] && ![orderModel.GubunBass isEqualToString:@"0D"]) {
      continue;
    }
    DrugNote *drugNote = [DrugNote initFromOrderModel:orderModel];
    [self.arrayDrug addObject:drugNote];
  }
  [self.tableContent reloadData];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  AddNewStandardDrugViewController *controller = [[AddNewStandardDrugViewController alloc] initWithNibName:NSStringFromClass([AddNewStandardDrugViewController class]) bundle:nil];
  controller.imageBackground = [UIUtils screenshot:self.view];
  controller.type = self.type;
  
  [tableView deselectRowAtIndexPath:indexPath animated:YES];
  
  if(indexPath.section == PHRMedicineAddRemider){
    
  } else {
    if(indexPath.row - 1 >=0){
      DrugNote  *obj = ([self.arrayDrug objectAtIndex:indexPath.row-1]);
      
      controller.data = obj;
      [self.navigationController presentViewController:controller animated:YES completion:nil];
    }
  }
}

@end
