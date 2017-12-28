//
//  BabyPrescriptionViewController.m
//  PHR
//
//  Created by BillyMobile on 6/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BabyPrescriptionViewController.h"
#import "AddNewDrugTableViewCell.h"
#import "AddRemiderTableViewCell.h"
#import "AddNewDrugFooter.h"
#import "AddNewDrugHeader.h"
#import "AddNewRemiderFooter.h"
#import "AddNewRemiderHeader.h"
#import "AddNewDrugViewController.h"
#import "IQActionSheetPickerView.h"
#import "AddBabyDrugViewController.h"

#define NUMBER_OF_SECTION 2
#define NUMBER_OF_REMIDER_NO_EXPANT 1
#define NUMBER_OF_ADD_DRUG 5

@interface BabyPrescriptionViewController ()<IQActionSheetPickerViewDelegate>{
    bool isExpant;
    int pageNumber;
    BOOL isFirstCome;
}

@end



@implementation BabyPrescriptionViewController


- (void)viewDidLoad {
    [super viewDidLoad];
    [self.tableContent setDelegate:self];
    [self.tableContent setDataSource:self];
    isExpant = YES;
    pageNumber = 1;
    isFirstCome = 1;
    
    NSString *apiId = PHRAppStatus.currentStandard.profileId;
    NSString *prescriptionId = self.prescriptionItem.prescription_id;
    self.arrayDrug = [[NSMutableArray alloc] init];
    
    [self initializeAddNewPresciption];
    
    if(apiId != nil && prescriptionId != nil){
        [self requestGetListDrugWithProfileId:apiId andPresciptionId:prescriptionId];
    }

    // Do any additional setup after loading the view from its nib.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)initializeAddNewPresciption {
    [self setupNavigationBarTitle:kLocalizedString(kTitleMedicine) titleIcon:@"Medicine Note" rightItem:[self itemRightBabyKey:kSave]];
    
    self.navBar.buttonRight.hidden = NO;
    self.lblPrescriptionName.font = [FontUtils aileronRegularWithSize:13.0];
    self.txtPrescriptionName.font = [FontUtils aileronRegularWithSize:14.0];
    
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
            }else{
                //[[UIApplication sharedApplication] cancelLocalNotification:noti];
            }
        }
    }
    
    
    
    [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddRemiderTableViewCell class]) bundle:nil] forCellReuseIdentifier:@"add_remider_cell"];
    [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewRemiderHeader class]) bundle:nil] forCellReuseIdentifier:@"add_remider_header_cell"];
    [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewRemiderFooter class]) bundle:nil] forCellReuseIdentifier:@"add_remider_footer_cell"];
    
    [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewDrugTableViewCell class]) bundle:nil] forCellReuseIdentifier:@"add_new_drug_cell"];
    [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewDrugHeader class]) bundle:nil] forCellReuseIdentifier:@"add_new_drug_header_cell"];
    [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([AddNewDrugFooter class]) bundle:nil] forCellReuseIdentifier:@"add_new_drug_footer_cell"];
    
    self.tableContent.showsHorizontalScrollIndicator = NO;
    self.tableContent.showsVerticalScrollIndicator = NO;
    
}

- (void)actionNavigationBarItemRight {
    if(self.isUpdate){
        [self updatePresscription];
    }else{
        [self addNewPresscription];
    }
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return NUMBER_OF_SECTION;
}


- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    if(section == PHRMedicineAddRemider){
        if(!isExpant){
            return NUMBER_OF_REMIDER_NO_EXPANT;
        }
        return self.arrayNotification.count + 2;
    }else{
        return self.arrayDrug.count+2;
    }
    
}



- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    if(indexPath.section == PHRMedicineAddRemider){
        
        if(isExpant){
            if(indexPath.row == 0){
                AddNewRemiderHeader *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_remider_header_cell" forIndexPath:indexPath];
                if (!cell) {
                    cell = [[AddNewRemiderHeader alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_remider_header_cell"];
                }
                
                
                cell.selectionStyle = UITableViewCellSelectionStyleNone;
                
                return cell;
            }else if(indexPath.row == self.arrayNotification.count+1){
                
                AddNewRemiderFooter *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_remider_footer_cell" forIndexPath:indexPath];
                if (!cell) {
                    cell = [[AddNewRemiderFooter alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_remider_footer_cell"];
                }
                
                cell.selectionStyle = UITableViewCellSelectionStyleNone;
                
                [cell setAddRemiderCallBack:^(){
                    // Date picker
                    IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:nil delegate:self];
                    [picker setTag:1];
                    [picker setActionSheetPickerStyle:IQActionSheetPickerStyleTimePicker];
                    picker.backgroundColor = [UIColor colorWithRed:1.0 green:1.0 blue:1.0 alpha:1.0];
                    //[picker setDate:self.datetime];
                    [picker show];
                }];
                return cell;
                
            }else{
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
            
        }else{
            AddNewRemiderHeader *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_remider_header_cell" forIndexPath:indexPath];
            if (!cell) {
                cell = [[AddNewRemiderHeader alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_remider_header_cell"];
            }
            
            cell.selectionStyle = UITableViewCellSelectionStyleNone;
            
            return cell;
        }
        
    }else{
        if(indexPath.row == 0){
            AddNewDrugHeader *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_new_drug_header_cell" forIndexPath:indexPath];
            if (!cell) {
                cell = [[AddNewDrugHeader alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_new_drug_header_cell"];
            }
            
            cell.selectionStyle = UITableViewCellSelectionStyleNone;
            
            return cell;
            
        }else if(indexPath.row == [self.arrayDrug count]+1){
            
            AddNewDrugFooter *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_new_drug_footer_cell" forIndexPath:indexPath];
            if (!cell) {
                cell = [[AddNewDrugFooter alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"add_new_drug_footer_cell"];
            }
            
            cell.selectionStyle = UITableViewCellSelectionStyleNone;
            
            [cell setAddDrugCallBack:^(){
                AddBabyDrugViewController *controller = [[AddBabyDrugViewController alloc] initWithNibName:NSStringFromClass([AddBabyDrugViewController class]) bundle:nil];
                controller.isUpdate = NO;
                controller.presID = self.prescriptionItem.prescription_id;
                [controller setAddDrugCallBack:^(){
                    [self refrestData];
                }];
                [self.navigationController pushViewController:controller animated:YES];
            }];
            
            return cell;

        }else{
            
            AddNewDrugTableViewCell *cell = [self.tableContent dequeueReusableCellWithIdentifier:@"add_new_drug_cell" forIndexPath:indexPath];
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

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    if(indexPath.section != PHRMedicineAddRemider){
        if(indexPath.row >0 && indexPath.row < self.arrayDrug.count+1){
            AddBabyDrugViewController *controller = [[AddBabyDrugViewController alloc] initWithNibName:NSStringFromClass([AddBabyDrugViewController class]) bundle:nil];
            
            DrugNote  *obj = ([self.arrayDrug objectAtIndex:indexPath.row-1]);
            controller.drugNote = obj;
            
            controller.isUpdate = YES;
            controller.presID = self.prescriptionItem.prescription_id;
            [controller setAddDrugCallBack:^(){
                [self refrestData];
            }];
            
            [self.navigationController pushViewController:controller animated:YES];
        }
    
    }
}

-(void) addNewPresscription{
    [[PHRClient instance] requestAddNewPrescription:nil andPres:self.txtPrescriptionName.text andDate:self.dateTimeView.stringDateParam completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                
                NSLog(@"%@",newDict);
                
                self.addPrescriptionCallBack();
                
                [self.navigationController popViewControllerAnimated:YES];
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

-(void) updatePresscription{
    [[PHRClient instance] requestAddNewPrescription:self.prescriptionItem.prescription_id andPres:self.txtPrescriptionName.text andDate:self.dateTimeView.stringDateParam completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                
                NSLog(@"%@",newDict);
            
                
                [self.navigationController popViewControllerAnimated:YES];
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

- (void) requestDeleteDrug:(NSString *)presID andDrugID:(NSString *)drugID{
    [[PHRClient instance] requestDeleteDrug:presID andDrugID:drugID completed:^(id response){
        [PHRAppDelegate hideLoading];
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if(status){
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
                
                NSLog(@"%@",newDict);
                [self refrestData];
                
                [self.tableContent reloadData];
                
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

-(void) fillData:(PresciptionObject *)prescriptionItem{
    self.txtPrescriptionName.text = self.prescriptionItem.prescription_name;
    [self.dateTimeView updateTime:[UIUtils dateFromString:self.prescriptionItem.datetime_record withFormat:PHR_SERVER_DATE_TIME_FORMAT] shortFormat:NO];

}

-(void) refrestData{
    pageNumber = 1;
    [self.arrayDrug removeAllObjects];
    NSString *apiId = PHRAppStatus.currentBaby.profileId;
    [self requestGetListDrugWithProfileId:apiId andPresciptionId:self.prescriptionItem.prescription_id];
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
        
        [self.tableContent reloadData];
        //[PHRAppDelegate hideLoading];
        //[self showOrHideLoading:NO];
    } error:^(NSString *error) {
        
        [PHRAppDelegate hideLoading];
        //[self showOrHideLoading:NO];
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
    }];
    
}

- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectDate:(NSDate*)date{
    
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
    
    [self.tableContent reloadData];
    
}


/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
