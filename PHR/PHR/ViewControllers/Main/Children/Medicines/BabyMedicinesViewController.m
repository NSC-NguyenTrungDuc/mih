//
//  BabyMedicinesViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 10/7/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabyMedicinesViewController.h"
#import "MedicineNoteViewController.h"
#import "PHRMedicineNoteTableViewCell.h"
#import "PHRMedicineTitleTableViewCell.h"
#import "PHRMStandardTableViewCell.h"
#import "DiseasesViewController.h"
#import "MedicineViewController.h"

static NSString *CellDetailIdentifier       = @"CellDetailIdentifier";
static NSString *CellTitleIdentifier        = @"CellTitleIdentifier";
static NSString *CellStandardIdentifier     = @"CellStandardIdentifier";

@interface BabyMedicinesViewController ()<UITableViewDelegate, UITableViewDataSource> {
    int pageNumber;
    BOOL isFirstCome;
    BOOL _isShow;
}
@property (strong, nonatomic) NSArray *menu;
@property (weak, nonatomic) IBOutlet UIImageView *mainBackground;

@end

@implementation BabyMedicinesViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    isFirstCome = YES;
    pageNumber = 1;
    _isShow = YES;
    
    self.refreshControl = [[UIRefreshControl alloc] init];
    [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
    [self.tableViewMedicines addSubview:self.refreshControl];
    
    [self.tableViewMedicines addPullToRefreshWithActionHandler:^{
        [self getMedicineFromServices];
    } position:SVPullToRefreshPositionBottom];
    
    [self initializeMedicinesView];
    
    if (!_expandedSections) {
        _expandedSections = [[NSMutableIndexSet alloc] init];
        self.arrayDateTime = [[NSMutableArray alloc] init];
        self.arrayMedicine = [[NSMutableArray alloc] init];
        self.arrayDiseaes = [[NSMutableArray alloc] init];
    }
    [self resetDataInView];
    [self getMedicineFromServices];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    
    if (self.type == PHRGroupTypeDiseaes) {
        [self setImageToBackgroundStandard:self.mainBackground];
    } else {
        if (self.type == PHRGroupTypeBaby) {
            [self setImageToBackgroundBaby:self.mainBackground];
        }else {
            [self setImageToBackgroundStandard:self.mainBackground];
        }
    }
    
}

- (void)resetDataInView{
    pageNumber = 1;
    if (self.arrayDateTime.count > 0) {
        [self.arrayDateTime removeAllObjects];
        [self.arrayMedicine removeAllObjects];
        [self.arrayDiseaes removeAllObjects];
    }
}

- (void)showOrHideLoading:(BOOL)isShowed{
    if (isShowed){
        //        [PHRAppDelegate showLoadingInView:self.tableViewMedicines];
    } else {
        [self.refreshControl endRefreshing];
        //        [PHRAppDelegate hideLoadingInView:self.tableViewMedicines];
    }
}

- (void)pullToRefreshData {
    [self resetDataInView];
    [self getMedicineFromServices];
}

- (void)getMedicineFromServices {
    NSString *apiId;
    [self showOrHideLoading:YES];
    if (self.type == PHRGroupTypeBaby) {
        apiId = PHRAppStatus.currentBaby.profileId;
        [self requestGetListMedicineWithProfileId:apiId];
    }
    if (self.type == PHRGroupTypeStandard) {
        apiId = PHRAppStatus.currentStandard.profileId;
        [self requestGetListMedicineWithProfileId:apiId];
    }
    if (self.type == PHRGroupTypeDiseaes) {
        apiId = PHRAppStatus.currentStandard.profileId;
        [self requestGetListDiseaesWithProfileId:apiId];
    }
}

- (void)requestGetListDiseaesWithProfileId:(NSString *)profileId {
    __weak __typeof__(self) weakSelf = self;
    //[PHRAppDelegate showLoading];
    [[PHRClient instance] requestGetListDiseases:[NSString stringWithFormat:@"%d",pageNumber] completed:^(id responseObj) {
        if (responseObj != nil) {
            NSLog(@"%@",responseObj);
            //NSArray *arrayRawData = [NSArray arrayWithArray:[responseObj valueForKeyPath:KEY_Content]];
            if ([[responseObj valueForKeyPath:KEY_Content] isKindOfClass:[NSArray class]]) {
                NSArray *result = (NSArray *)[responseObj valueForKeyPath:KEY_Content];
                
                //weakSelf.arrayDiseaes = [[DataManager sharedManager] getArrayDieases:result];
                weakSelf.arrayDateTime = [[DataManager sharedManager] getArrayDateForDieases:result];
                
                if (weakSelf.arrayDiseaes.count == 0 && isFirstCome) {
                    isFirstCome = NO;
                    [weakSelf performSelector:@selector(addNewDiseaes:) withObject:nil afterDelay:1.0];
                }
                else {
                    pageNumber += 1;
                    [weakSelf.tableViewMedicines reloadData];
                }
            }
            
            if (weakSelf.arrayDateTime.count && _isShow) {
                for (int i = 0; i < weakSelf.arrayDateTime.count; i++) {
                    NSIndexPath *indexPath = [NSIndexPath indexPathForRow:0.0 inSection:i];
                    [self tableView:weakSelf.tableViewMedicines didSelectRowAtIndexPath:indexPath];
                }
            }
            [self showOrHideLoading:NO];
        }
        [self showOrHideLoading:NO];
    } error:^(NSString * error) {
        [self showOrHideLoading:NO];
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
    }];
    
    [weakSelf.tableViewMedicines.pullToRefreshView stopAnimating];
}


- (void)requestGetListMedicineWithProfileId:(NSString *)profileId {
    __weak __typeof__(self) weafSelf = self;
    //[PHRAppDelegate showLoading];
    [[PHRClient instance] requestMedicinesWithApiID:profileId andNumberPage:pageNumber andCompleted:^(id params) {
        id response = [params objectForKey:KEY_Content];
        if ([response isKindOfClass:[NSArray class]]) {
            NSArray *resultMedicines = (NSArray *)response;
            for (int i = 0; i < resultMedicines.count; i++) {
                NSDictionary *dict = [resultMedicines objectAtIndex:i];
                NSDate *dateTime   = [UIUtils dateFromServerTimeString:[dict objectForKey:KEY_MedicineNote_Time]];
                
                MedicineNote *objNote = [MedicineNote initializeMedicinFrom:dict];
                [weafSelf.arrayMedicine addObject:objNote];
                
                if (weafSelf.arrayDateTime.count > 0) {
                    BOOL isAdd = YES;
                    for (NSString *objDate in weafSelf.arrayDateTime) {
                        if ([objDate isEqualToString:[UIUtils formatDateOppositeStyle:dateTime]]) {
                            isAdd = NO;
                        }
                    }
                    if (isAdd) {
                        [weafSelf.arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
                    }
                }
                else {
                    [weafSelf.arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
                }
            }
            
            if (weafSelf.arrayMedicine.count > 0) {
                weafSelf.arrayMedicine = [weafSelf timeSortedBegins];
            }
        }
        
        if (weafSelf.arrayMedicine.count == 0 && isFirstCome) {
            isFirstCome = NO;
            [weafSelf performSelector:@selector(addNewMedicine:) withObject:nil afterDelay:1.0];
        }
        else {
            pageNumber += 1;
            [weafSelf.tableViewMedicines reloadData];
        }
        if (weafSelf.arrayDateTime.count && _isShow) {
            for (int i = 0; i < weafSelf.arrayDateTime.count; i++) {
                NSIndexPath *indexPath = [NSIndexPath indexPathForRow:0.0 inSection:i];
                [self tableView:weafSelf.tableViewMedicines didSelectRowAtIndexPath:indexPath];
            }
        }
        
        //[PHRAppDelegate hideLoading];
        [self showOrHideLoading:NO];
    } error:^(NSString *error) {
        //[PHRAppDelegate hideLoading];
        [self showOrHideLoading:NO];
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
    }];
    
    [weafSelf.tableViewMedicines.pullToRefreshView stopAnimating];
}

- (NSMutableArray*) timeSortedBegins {
    NSMutableArray* begins = self.arrayMedicine;
    NSSortDescriptor *sort = [[NSSortDescriptor alloc] initWithKey:@"time_take_medicine" ascending:YES];
    [begins sortUsingDescriptors: @[sort]];
    return begins;
}

- (NSMutableArray *)getArrayDateForDieases:(NSMutableArray *)list {
    NSMutableArray *arrayDateTime = [[NSMutableArray alloc] init];
    
    for (int i = 0; i < list.count; i++) {
        DiseasesModel *dict = (DiseasesModel*) [list objectAtIndex:i];
        NSDate *dateTime = [UIUtils dateFromServerTimeString:dict.datetime_record];
        
        if (arrayDateTime.count > 0) {
            BOOL isAdd = YES;
            for (NSString *objDate in arrayDateTime) {
                if ([objDate isEqualToString:[UIUtils formatDateOppositeStyle:dateTime]]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
            }
        }
        else {
            [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
        }
    }
    return arrayDateTime;
}


- (NSMutableArray *)getArrayDateForMedicine:(NSMutableArray *)list {
    NSMutableArray *arrayDateTime = [[NSMutableArray alloc] init];
    
    for (int i = 0; i < list.count; i++) {
        MedicineNote *dict = (MedicineNote*)[list objectAtIndex:i];
        
        if (arrayDateTime.count > 0) {
            BOOL isAdd = YES;
            for (NSString *objDate in arrayDateTime) {
                if ([objDate isEqualToString:dict.date]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [arrayDateTime addObject:dict.date];
            }
        }
        else {
            [arrayDateTime addObject:dict.date];
        }
    }
    return arrayDateTime;
}

#pragma mark - Override method

- (void)actionNavigationBarItemRight {
    if (self.type == PHRGroupTypeDiseaes) {
        //        DiseasesViewController *controller = [[DiseasesViewController alloc] initWithNibName:NSStringFromClass([DiseasesViewController class]) bundle:nil];
        //        controller.type = self.type;
        //        [self.navigationController pushViewController:controller animated:YES];
        [self addNewDiseaes:nil];
    }
    else {
        [self addNewMedicine:nil];
    }
}

- (void)addNewMedicine:(id)sender {
    MedicineNoteViewController *controller = [[MedicineNoteViewController alloc] initWithNibName:NSStringFromClass([MedicineNoteViewController class]) bundle:nil];
    controller.type = self.type;
    [controller setAddMedicineNoteCallBack:^(BabyMedicineModel *type) {
        MedicineNote* note = [MedicineNote initializeMedicinFromModel:type];
        [self.arrayMedicine addObject:note];
        [self reDisplayDataForMedicine];
    }];
    [self.navigationController pushViewController:controller animated:YES];
}

- (void)addNewDiseaes:(id)sender {
    DiseasesViewController *controller = [[DiseasesViewController alloc] initWithNibName:NSStringFromClass([DiseasesViewController class]) bundle:nil];
    [controller setAddDiseasesCallBack:^(DiseasesModel *type) {
        [self.arrayDiseaes addObject:type];
        [self reDisplayDataForDieases];
    }];
    controller.type = self.type;
    [self.navigationController pushViewController:controller animated:YES];
}

#pragma mark - UI Style

- (void)initializeMedicinesView {
    if (self.type == PHRGroupTypeDiseaes) {
        [self setupNavigationBarTitle:kLocalizedString(kTitleDiseases) titleIcon:@"icon_title_injuries" rightItem:[self itemRightBabyKey:kAdd]];
        [self.BG_TableView setImage:[UIImage imageNamed:@"BGBabyPink"]];
        [self.BG_TableView setAlpha:0.8];
        //[self setImageToBackgroundStandard:self.mainBackground];
    } else {
        [self setupNavigationBarTitle:kLocalizedString(kTitleMedicine) titleIcon:@"Medicine Note" rightItem:[self itemRightBabyKey:kAdd]];
        if (self.type == PHRGroupTypeBaby) {
            //[self setImageToBackgroundBaby:self.mainBackground];
            [self.BG_TableView setImage:[UIImage imageNamed:@"BGBabyPink"]];
            [self.BG_TableView setAlpha:0.8];
        }
        else {
            //[self setImageToBackgroundStandard:self.BG_TableView];
            [self.BG_TableView setImage:[UIImage imageNamed:@"BGBabyPink"]];
            [self.BG_TableView setAlpha:0.8];
            //[self setImageToBackgroundStandard:self.mainBackground];
        }
    }
    
    [self setStyleToTableView:self.tableViewMedicines withTag:1];
}

- (void)setStyleToTableView:(UITableView *)tableView withTag:(NSInteger)tagTableView {
    tableView.delegate = self;
    tableView.dataSource = self;
    
    [tableView setBackgroundColor:[UIColor clearColor]];
    [tableView setSeparatorStyle:UITableViewCellSeparatorStyleNone];
    
    [self.tableViewMedicines registerNib:[UINib nibWithNibName:NSStringFromClass([PHRMedicineNoteTableViewCell class]) bundle:nil] forCellReuseIdentifier:CellDetailIdentifier];
    [self.tableViewMedicines registerNib:[UINib nibWithNibName:NSStringFromClass([PHRMedicineTitleTableViewCell class]) bundle:nil] forCellReuseIdentifier:CellTitleIdentifier];
    [self.tableViewMedicines registerNib:[UINib nibWithNibName:NSStringFromClass([PHRMStandardTableViewCell class]) bundle:nil] forCellReuseIdentifier:CellStandardIdentifier];
}

#pragma mark - TableView Data Source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    // Return the number of sections.
    if (self.arrayDateTime.count > 0) {
        return self.arrayDateTime.count;
    }
    return 0;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    if (self.arrayDateTime.count > 0) {
        NSString *dateTime = [self.arrayDateTime objectAtIndex:section];
        
        if (self.type == PHRGroupTypeDiseaes) {
            NSMutableArray *diseaess = [self getArrayDieasesWithDateTime:dateTime];
            if ([_expandedSections containsIndex:section]) {
                return diseaess.count + 1;
            }
            return 1;
        }
        else {
            NSMutableArray *medicines = [self getArrayWithDateTime:dateTime];
            if ([_expandedSections containsIndex:section]) {
                return medicines.count + 1;
            }
            return 1;
        }
    }
    // Return the number of rows in the section.
    return 0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    // Configure the cell...
    if (indexPath.row == 0) {
        PHRMedicineTitleTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellTitleIdentifier];
        if (cell == nil) {
            cell = [[PHRMedicineTitleTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellTitleIdentifier];
        }
        
        // first row
        if (self.arrayDateTime.count > 0) {
            NSString *objDate = [self.arrayDateTime objectAtIndex:indexPath.section];
            if ([[UIUtils formatDateOppositeStyle:[NSDate date]] isEqualToString:objDate]) {
                [cell setStyleToHeaderTableViewWithTitle:kLocalizedString(kToday) andDate:objDate];
            }
            else {
                [cell setStyleToHeaderTableViewWithTitle:objDate andDate:nil];
            }
        }
        
        if ([self.expandedSections containsIndex:indexPath.section]) {
            cell.accessoryView = [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeRight];
        }
        else {
            cell.accessoryView = [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeDown];
        }
        return cell;
    }
    else {
        NSString *dateTime = [self.arrayDateTime objectAtIndex:indexPath.section];
        if (self.type == PHRGroupTypeDiseaes) {
            PHRMStandardTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellStandardIdentifier];
            [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
            [cell setBackgroundColor:[UIColor clearColor]];
            
            if (cell == nil) {
                cell = [[PHRMStandardTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellStandardIdentifier];
            }
            
            NSMutableArray *diseaess = [NSMutableArray new];
            for (int i = 0; i < self.arrayDiseaes.count; i++) {
                DiseasesModel *model = [self.arrayDiseaes objectAtIndex:i];
                if ([[UIUtils formatDateOppositeStyle:[UIUtils dateFromServerTimeString:model.datetime_record]] isEqualToString:dateTime]) {
                    [diseaess addObject:model];
                }
            }
            
            DiseasesModel *objModel = [diseaess objectAtIndex:(indexPath.row - 1)];
            [cell setUpViewStyleWithDieasesObject:objModel];
            
            return cell;
        }
        
        else {
            if(self.arrayMedicine.count > 0) {
                if (self.type == PHRGroupTypeBaby) {
                    NSMutableArray *medicines = [NSMutableArray new];
                    for (int i = 0; i < self.arrayMedicine.count; i++) {
                        MedicineNote *objNote = [self.arrayMedicine objectAtIndex:i];
                        if ([objNote.date isEqualToString:dateTime]) {
                            [medicines addObject:objNote];
                        }
                    }
                    
                    MedicineNote *medicine_note = [medicines objectAtIndex:(indexPath.row - 1)];
                    
                    PHRMedicineNoteTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellDetailIdentifier];
                    [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
                    
                    if (cell == nil) {
                        cell = [[PHRMedicineNoteTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellDetailIdentifier];
                    }
                    
                    cell.userInteractionEnabled = YES;
                    [cell setDataMedicineToCell:medicine_note];
                    [cell setBackgroundColor:[UIColor clearColor]];
                    return cell;
                }
                else if (self.type == PHRGroupTypeStandard) {
                    NSMutableArray *medicines = [self getArrayWithDateTime:dateTime];
                    MedicineNote *medicine_note = [medicines objectAtIndex:(indexPath.row - 1)];
                    
                    PHRMStandardTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellStandardIdentifier];
                    [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
                    
                    if (cell == nil) {
                        cell = [[PHRMStandardTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellStandardIdentifier];
                    }
                    
                    [cell setUpViewStyleWithMedicineNote:medicine_note];
                    [cell setBackgroundColor:[UIColor clearColor]];
                    return cell;
                }
            }
        }
    }
    return nil;
}

- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        NSString *dateTime = [self.arrayDateTime objectAtIndex:indexPath.section];
        
        __weak __typeof(self) weakSelf = self;
        
        if (self.type == PHRGroupTypeBaby) {
            NSMutableArray *medicines = [self getArrayWithDateTime:dateTime];
            MedicineNote *medicine_note = [medicines objectAtIndex:(indexPath.row - 1)];
            [[PHRClient instance] requestDeleteObject:PHRAppStatus.currentBaby.profileId and:[NSString stringWithFormat:@"%d", medicine_note.medicine_note_id] andMethod:API_MedicineNote completion:^(MFResponse *result) {
                if (result) {
                    [weakSelf.arrayMedicine removeObject:medicine_note];
                    [weakSelf reDisplayDataForMedicine];
                }
                else {
                    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                }
            }];
        } else if (self.type == PHRGroupTypeDiseaes) {
            NSMutableArray *medicines = [self getArrayDieasesWithDateTime:dateTime];
            DiseasesModel *diseases = [medicines objectAtIndex:(indexPath.row - 1)];
            [[PHRClient instance] requestDeleteObject:PHRAppStatus.currentStandard.profileId and:[NSString stringWithFormat:@"%@",diseases.disease_id]
                                            andMethod:API_StandardDiseases completion:^(MFResponse *result) {
                                                if (result) {
                                                    [weakSelf.arrayDiseaes removeObject:diseases];
                                                    [weakSelf reDisplayDataForDieases];
                                                }
                                                else {
                                                    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                                                }
                                            }];
        } else {
            NSMutableArray *medicines = [self getArrayWithDateTime:dateTime];
            MedicineNote *medicine_note = [medicines objectAtIndex:(indexPath.row - 1)];
            [[PHRClient instance] requestDeleteObject:PHRAppStatus.currentStandard.profileId and:[NSString stringWithFormat:@"%d", medicine_note.medicine_note_id]
                                            andMethod:API_MedicineNote completion:^(MFResponse *result) {
                                                if (result) {
                                                    [weakSelf.arrayMedicine removeObject:medicine_note];
                                                    //[weakSelf.tableViewMedicines reloadData];
                                                    [weakSelf reDisplayDataForMedicine];
                                                }
                                                else {
                                                    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                                                }
                                            }];
        }
    }
}

#pragma mark - TableView Delegate

- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
    if (!indexPath.row) {
        return NO;
    }
    return YES;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    if (!indexPath.row) {
        // only first row toggles exapand/collapse
        [tableView deselectRowAtIndexPath:indexPath animated:YES];
        
        NSInteger section = indexPath.section;
        BOOL currentlyExpanded = [_expandedSections containsIndex:section];
        NSInteger rows;
        
        NSMutableArray *tmpArray = [NSMutableArray array];
        
        if (currentlyExpanded) {
            rows = [self tableView:tableView numberOfRowsInSection:section];
            [_expandedSections removeIndex:section];
        }
        else {
            [_expandedSections addIndex:section];
            rows = [self tableView:tableView numberOfRowsInSection:section];
        }
        
        for (int i = 1; i < rows; i++) {
            NSIndexPath *tmpIndexPath = [NSIndexPath indexPathForRow:i
                                                           inSection:section];
            [tmpArray addObject:tmpIndexPath];
        }
        
        UITableViewCell *cell = [tableView cellForRowAtIndexPath:indexPath];
        
        if (currentlyExpanded) {
            _isShow = YES;
            [tableView deleteRowsAtIndexPaths:tmpArray
                             withRowAnimation:UITableViewRowAnimationTop];
            
            cell.accessoryView = [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeDown];
        }
        else {
            _isShow = NO;
            [tableView insertRowsAtIndexPaths:tmpArray
                             withRowAnimation:UITableViewRowAnimationTop];
            cell.accessoryView =  [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeRight];
        }
    }
    else {
        DLog(@"Selected Section is %ld and subrow is %ld ",(long)indexPath.section,(long)indexPath.row);
        if (self.type == PHRGroupTypeDiseaes) {
            if (self.arrayDiseaes.count > 0) {
                NSString *dateTime = [self.arrayDateTime objectAtIndex:indexPath.section];
                NSMutableArray *diseaes = [self getArrayDieasesWithDateTime:dateTime];
                DiseasesModel *model = [diseaes objectAtIndex:(indexPath.row - 1)];
                
                DiseasesViewController *controller = [[DiseasesViewController alloc] initWithNibName:NSStringFromClass([DiseasesViewController class]) bundle:nil];
                controller.id_diseases = model.disease_id;
                controller.type = self.type;
                controller.model = model;
                
                [controller setAddDiseasesCallBack:^(DiseasesModel *type) {
                    BOOL isUpdated = NO;
                    for (int i = 0; i < self.arrayDiseaes.count; i++) {
                        DiseasesModel *obj = (DiseasesModel*) self.arrayDiseaes[i];
                        if (obj.disease_id == type.disease_id) {
                            self.arrayDiseaes[i] = type;
                            isUpdated = YES;
                            NSLog(@"[UPDATED]");
                        }
                        if (isUpdated) {
                            NSLog(@"[BREAK]");
                            break;
                        }
                    }
                    [self reDisplayDataForDieases];
                }];
                [self.navigationController pushViewController:controller animated:YES];
            }
        }
        else {
            if (self.arrayMedicine.count > 0) {
                NSString *dateTime = [self.arrayDateTime objectAtIndex:indexPath.section];
                NSMutableArray *medicines = [self getArrayWithDateTime:dateTime];
                
                MedicineNote *medicine_note = [medicines objectAtIndex:(indexPath.row - 1)];
                MedicineNoteViewController *openMedicineVC = [[MedicineNoteViewController alloc]initWithNibName:NSStringFromClass([MedicineNoteViewController class]) bundle:nil];
                openMedicineVC.id_medicine = [NSString stringWithFormat:@"%d", medicine_note.medicine_note_id];
                openMedicineVC.type = self.type;
                [openMedicineVC setAddMedicineNoteCallBack:^(BabyMedicineModel *type) {
                    BOOL isUpdated = NO;
                    for (int i = 0; i < self.arrayMedicine.count; i++) {
                        MedicineNote *obj = (MedicineNote*) self.arrayMedicine[i];
                        if (obj.medicine_note_id == [type.id intValue]) {
                            self.arrayMedicine[i] = [MedicineNote initializeMedicinFromModel:type];
                            isUpdated = YES;
                            NSLog(@"[UPDATED]");
                        }
                        if (isUpdated) {
                            NSLog(@"[BREAK]");
                            break;
                        }
                    }
                    [self reDisplayDataForMedicine];
                }];
                [self.navigationController pushViewController:openMedicineVC animated:YES];
            }
        }
    }
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    if(!indexPath.row) {
        return 40.0;
    }
    if (self.type == PHRGroupTypeBaby) {
        return 70.0;
    }
    return 80.0f;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section {
    return 0.0;
}

- (CGFloat)tableView:(UITableView *)tableView heightForFooterInSection:(NSInteger)section {
    return 0.0;
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section {
    return [UIView new];
}

- (UIView *)tableView:(UITableView *)tableView viewForFooterInSection:(NSInteger)section {
    return [UIView new];
}

#pragma mark - Get Array From Date
- (void)reDisplayDataForMedicine{
    //self.arrayMedicine = [self timeSortedBegins:self.arrayMedicine];
    //[self drawChart];
    self.arrayDateTime = [self getArrayDateForMedicine:self.arrayMedicine];
    [self.tableViewMedicines reloadData];
}

- (void)reDisplayDataForDieases{
    //self.arrayMedicine = [self timeSortedBegins:self.arrayMedicine];
    //[self drawChart];
    self.arrayDateTime = [self getArrayDateForDieases:self.arrayDiseaes];
    [self.tableViewMedicines reloadData];
}

- (NSMutableArray *)getArrayWithDateTime:(NSString *)dateTime {
    NSMutableArray *medicines = [NSMutableArray new];
    for (int i = 0; i < self.arrayMedicine.count; i++) {
        MedicineNote *objNote = [self.arrayMedicine objectAtIndex:i];
        if ([objNote.date isEqualToString:dateTime]) {
            [medicines addObject:objNote];
        }
    }
    
    return medicines;
}

- (NSMutableArray *)getArrayDieasesWithDateTime:(NSString *)dateTime {
    NSMutableArray *diseaess = [NSMutableArray new];
    for (int i = 0; i < self.arrayDiseaes.count; i++) {
        DiseasesModel *model = [self.arrayDiseaes objectAtIndex:i];
        if ([[UIUtils formatDateOppositeStyle:[UIUtils dateFromServerTimeString:model.datetime_record]] isEqualToString:dateTime]) {
            [diseaess addObject:model];
        }
    }
    
    return diseaess;
}

- (void)getArrayMedicineWithDate:(NSMutableArray *)input{
    for (int i = 0; i < input.count; i++) {
        NSDictionary *dict = [input objectAtIndex:i];
        NSDate *day = [UIUtils dateFromServerTimeString:[dict valueForKeyPath:KEY_MedicineNote_Time]];
        
        if (self.arrayDateTime.count > 0) {
            BOOL isAdd = YES;
            for (NSString *dateTime in self.arrayDateTime) {
                if ([dateTime isEqualToString:[UIUtils formatDateOppositeStyle:day]]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [self.arrayDateTime addObject:[UIUtils formatDateOppositeStyle:day]];
            }
        }
        else {
            [self.arrayDateTime addObject:[UIUtils formatDateOppositeStyle:day]];
        }
    }
}

- (void)getArrayDieasesWithDate:(NSMutableArray *)input{
    for (int i = 0; i < input.count; i++) {
        NSDictionary *dict = [input objectAtIndex:i];
        NSDate *day = [UIUtils dateFromServerTimeString:[dict valueForKeyPath:KEY_DateRecord]];
        
        if (self.arrayDateTime.count > 0) {
            BOOL isAdd = YES;
            for (NSString *dateTime in self.arrayDateTime) {
                if ([dateTime isEqualToString:[UIUtils formatDateOppositeStyle:day]]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [self.arrayDateTime addObject:[UIUtils formatDateOppositeStyle:day]];
            }
        }
        else {
            [self.arrayDateTime addObject:[UIUtils formatDateOppositeStyle:day]];
        }
    }
}

- (NSMutableArray*)generateDataLikeJSONForMedicine:(NSMutableArray*)inputArray{
    NSMutableArray* result = [[NSMutableArray alloc]init];
    for (id object in inputArray) {
        if ([object isKindOfClass:[MedicineNote class]]) {
            MedicineNote* medicineObj = (MedicineNote*) object;
            NSDictionary *medicineDict =[NSDictionary dictionaryWithObjectsAndKeys:
                                         medicineObj.time_take_medicine,KEY_MedicineNote_Time,
                                         //medicineObj.time_pee_poo,KEY_BabyDiaper_Time,
                                         nil];
            [result addObject:medicineDict];
        }
    }
    return result;
}

- (NSMutableArray*)generateDataLikeJSONForDieases:(NSMutableArray*)inputArray{
    NSMutableArray* result = [[NSMutableArray alloc]init];
    for (id object in inputArray) {
        if ([object isKindOfClass:[DiseasesModel class]]) {
            DiseasesModel* diseasesObj = (DiseasesModel*) object;
            NSDictionary *diseases =[NSDictionary dictionaryWithObjectsAndKeys:
                                     diseasesObj.disease_name,KEY_disease_name,
                                     diseasesObj.datetime_record,KEY_datetime_record,
                                     nil];
            [result addObject:diseases];
        }
    }
    return result;
}

@end
