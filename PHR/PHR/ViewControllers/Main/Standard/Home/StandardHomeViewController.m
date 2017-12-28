//
//  StandardHomeViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "StandardHomeViewController.h"
#import "DiseasesViewController.h"
#import "StandardHomeDateCell.h"
#import "StandardHomeCell.h"
#import "DiseasesListViewController.h"
#import "ProgressCourseNoteViewController.h"
#import "ProfileViewController.h"
#import "Setting+CoreDataProperties.h"
#import "PHRLifeStyleNoteViewController.h"
#import "LocalStorageImage.h"
#import "MedicineViewController.h"
#import "StandardItemSelected.h"
#import "MasterDataManager.h"
#import "StandardFitnessDetailViewController.h"
#import "HealthRecordViewController.h"
#import "StandardFoodDetailViewController.h"
#import "BodyMeasurementDetailViewController.h"
#import "StandardVitalsDetailViewController.h"
#import "PatientClinicViewController.h"
#import "PHRBookingListViewController.h"

@interface StandardHomeViewController () {
    BOOL defaultBackground;
}
@property (nonatomic, strong) HYActivityView *activityView;
// Standard item
@property (nonatomic, strong) StandardHomeItem *itemBodyMeasurement;
@property (nonatomic, strong) StandardHomeItem *itemFitness;
@property (nonatomic, strong) StandardHomeItem *itemFood;
@property (nonatomic, strong) StandardHomeItem *itemMedicine;
@property (nonatomic, strong) StandardHomeItem *itemHealthRecord;
@property (nonatomic, strong) StandardHomeItem *itemTemperature;
@property (nonatomic, strong) StandardHomeItem *itemLifeStyle;
@property (nonatomic, strong) StandardHomeItem *itemMovieTalk;
@property (nonatomic, strong) NSMutableArray* arrayHomeItem;
@end

@implementation StandardHomeViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self setupHomeNavigationBar:PHRGroupTypeStandard];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(updateItemOfCollectionView:) name:SelectedPropertyInStandard object:nil];
    [self.viewOpacity setBackgroundColor:[[UIColor blackColor] colorWithAlphaComponent:0.3]];
    // Register cell
    [self.collectionViewStandard registerNib:[UINib nibWithNibName:NSStringFromClass([StandardHomeDateCell class]) bundle:nil] forCellWithReuseIdentifier:NSStringFromClass([StandardHomeDateCell class])];
    [self.collectionViewStandard registerNib:[UINib nibWithNibName:NSStringFromClass([StandardHomeCell class]) bundle:nil] forCellWithReuseIdentifier:NSStringFromClass([StandardHomeCell class])];
    self.arrayHomeItem = [[NSMutableArray alloc] init];
    // ---- SLEEP NOTICE -----
    // Show rating sleep dialog and cancel notification
    NSString *sleepTime = [NSUtils valueForKey:[@(StandardHomeTypeLifeStyle) stringValue]];
    NSArray *arrayTime = [sleepTime componentsSeparatedByString:@"ProfileID"];
    
    if(sleepTime != nil && [arrayTime[1] isEqualToString:PHRAppStatus.currentStandard.profileId]){
        NSMutableArray *allNotifications = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] scheduledLocalNotifications]];
        for (UILocalNotification *noti in allNotifications) {
            NSString *notiID = [noti.userInfo valueForKey:@"ID"];
            
            if(notiID !=nil && [[NSString stringWithFormat:@"%@",notiID] containsString:@"AlarmNotification"]){
                [[UIApplication sharedApplication] cancelLocalNotification:noti];
                break;
            }
        }
        [NSUtils removeObjectForKey:[@(StandardHomeTypeLifeStyle) stringValue]];
        self.ratingScreen.startSleepTime = arrayTime[0];
        [self.ratingScreen showInView:self.view];
    }
    
    // Init home item
    [self initHomeItemList];
    // Get home data
    [self getStandardHomeData];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(getStandardHomeData) name:kNotifyProfileStandardActiveChanged object:nil];
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    
    [self setImageToBackgroundStandard:self.backgroundStandard];
}

- (void)viewWillDisappear:(BOOL)animated{
    [super viewWillDisappear:animated];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (NSMutableArray*)listItemDisplay{
    NSMutableArray *arr = [[NSMutableArray alloc] init];
    for (StandardHomeItem *item in self.arrayItems) {
        if (item.isDisplay) {
            [arr addObject:item];
        }
    }
    return arr;
}

- (StandardHomeItem*)itemDisplayAtIndex:(NSInteger)index{
    NSInteger display = 0;
    for (StandardHomeItem *item in self.arrayItems) {
        if (item.isDisplay) {
            if (display == index) {
                return item;
            }
            display++;
        }
    }
    return nil;
}

- (StandardHomeItem*)homeItemWithType:(StandardHomeType)type{
    if (type == StandardHomeTypeBodyMeasurement) {
        return _itemBodyMeasurement;
    }
    if (type == StandardHomeTypeFitness) {
        return _itemFitness;
    }
    if (type == StandardHomeTypeFood) {
        return _itemFood;
    }
    if (type == StandardHomeTypeMedicine) {
        return _itemMedicine;
    }
    if (type == StandardHomeTypeHealthRecord) {
        return _itemHealthRecord;
    }
    if (type == StandardHomeTypeTemprature) {
        return _itemTemperature;
    }
    if (type == StandardHomeTypeLifeStyle) {
        return _itemLifeStyle;
    }
    if (type == StandardHomeTypeMovieTalk) {
        return _itemMovieTalk;
    }
    return nil;
}

- (void)initHomeItemList{
    _itemBodyMeasurement = [StandardHomeItem initWithType:StandardHomeTypeBodyMeasurement
                                                     name:kLocalizedString(kTitleBodyMeasurement)
                                                  subUnit:kLocalizedString(kUnitBmi)
                                                    value:0
                                                isPercent:NO];
     _itemFood = [StandardHomeItem initWithType:StandardHomeTypeFood
                                           name:kLocalizedString(kTitleFood)
                                        subUnit:kLocalizedString(kRateGood)
                                          value:0
                                      isPercent:YES];
    _itemFitness = [StandardHomeItem initWithType:StandardHomeTypeFitness
                                             name:kLocalizedString(kTitleFitness)
                                          subUnit:nil
                                            value:0
                                        isPercent:NO];
    _itemLifeStyle = [StandardHomeItem initWithType:StandardHomeTypeLifeStyle
                                              name:kLocalizedString(kTitleLifeStyle)
                                           subUnit:nil
                                             value:0
                                         isPercent:NO];
    _itemTemperature = [StandardHomeItem initWithType:StandardHomeTypeTemprature
                                                 name:kLocalizedString(KTitleTemperature)
                                              subUnit:nil
                                                value:0
                                            isPercent:NO];
    _itemHealthRecord = [StandardHomeItem initWithType:StandardHomeTypeHealthRecord
                                                  name:kLocalizedString(kTitleHealthRecord)
                                               subUnit:nil
                                                 value:0
                                             isPercent:YES];
    _itemMedicine = [StandardHomeItem initWithType:StandardHomeTypeMedicine
                                              name:kLocalizedString(kTitleMedicine)
                                           subUnit:nil
                                             value:0
                                         isPercent:YES];
    _itemMovieTalk = [StandardHomeItem initWithType:StandardHomeTypeMovieTalk
                                               name:kLocalizedString(kTitleMovieTalk)
                                            subUnit:nil
                                              value:0
                                          isPercent:NO];
    self.arrayItems = @[_itemBodyMeasurement, _itemFood, _itemFitness, _itemLifeStyle ,_itemTemperature, _itemHealthRecord,  _itemMedicine, _itemMovieTalk];
}

- (void)initializeView {
    _itemBodyMeasurement.isDisplay = YES;
    _itemFitness.isDisplay = YES;
    _itemFood.isDisplay = YES;
    _itemMedicine.isDisplay = YES;
    _itemHealthRecord.isDisplay = YES;
    _itemTemperature.isDisplay = YES;
    _itemLifeStyle.isDisplay = YES;
    _itemMovieTalk.isDisplay = YES;
    _arrayHomeItem = [self listItemDisplay];
    NSArray *list = [[DataManager sharedManager] findUserSettingWithUserName:PHRAppStatus.email];
    if (list.count > 0) {
        for (Setting *setting in list) {
            switch ((StandardHomeType)setting.itemType) {
                case StandardHomeTypeBodyMeasurement:
                    _itemBodyMeasurement.isDisplay = setting.display;
                    break;
                case StandardHomeTypeFitness:
                    _itemFitness.isDisplay = setting.display;
                    break;
                case StandardHomeTypeFood:
                    _itemFood.isDisplay = setting.display;
                    break;
                case StandardHomeTypeMedicine:
                    _itemMedicine.isDisplay = setting.display;
                    break;
                case StandardHomeTypeHealthRecord:
                    _itemHealthRecord.isDisplay = setting.display;
                    break;
                case StandardHomeTypeTemprature:
                    _itemTemperature.isDisplay = setting.display;
                    break;
                case StandardHomeTypeLifeStyle:
                    _itemLifeStyle.isDisplay = setting.display;
                    break;
                case StandardHomeTypeMovieTalk:
                    _itemMovieTalk.isDisplay = setting.display;
                    break;
                default:
                    break;
            }
        }
    }
    else {
        for (StandardHomeItem *item in self.arrayItems) {
            Setting *setting = [Setting create];
            setting.username = PHRAppStatus.email;
            setting.display = YES;
            setting.itemType = item.type;
            [setting save];
        }
    }
    [self.collectionViewStandard reloadData];
}

- (void)showOrHideLoading:(BOOL)isShowed {
    if (isShowed) {
        [PHRAppDelegate showLoadingInView:self.viewLoading];
    } else {
        [PHRAppDelegate hideLoadingInView:self.viewLoading];
    }
}

- (void)getStandardHomeData {
    if (!PHRAppStatus.currentStandard || !PHRAppStatus.currentStandard.profileId){
        if (_arrayHomeItem != nil && (id)_arrayHomeItem != [NSNull null] && [_arrayHomeItem count] > 0) {
            [_arrayHomeItem removeAllObjects];
        }
        [self.collectionViewStandard reloadData];
        // do not have any profile to show
        return;
    }
    [self initializeView];
}

#pragma mark - Collection view delegate

// ------ Collection view delegate -------
- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {
    return self.arrayHomeItem.count + 1;
}

- (UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row == 0) {
        // Item datetime
        StandardHomeDateCell *cell = (StandardHomeDateCell *)[collectionView dequeueReusableCellWithReuseIdentifier:NSStringFromClass([StandardHomeDateCell class]) forIndexPath:indexPath];
        return cell;
    }
    // item >= 1
    StandardHomeCell *cell = (StandardHomeCell *)[collectionView dequeueReusableCellWithReuseIdentifier:NSStringFromClass([StandardHomeCell class]) forIndexPath:indexPath];
    [cell fillHomeItem:[self itemDisplayAtIndex:indexPath.row - 1]];
    return cell;
}

- (CGSize)collectionView:(UICollectionView *)collectionView layout:(UICollectionViewLayout*)collectionViewLayout sizeForItemAtIndexPath:(NSIndexPath *)indexPath
{
    return CGSizeMake((SCREEN_WIDTH - 60)/2, 142);
}

- (void)collectionView:(UICollectionView *)collectionView didSelectItemAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row < 1) {
        // Click at Date cell
        return;
    }
    NSInteger index = 0;
    StandardHomeItem *selectedItem = nil;
    for (NSInteger i = 0; i < self.arrayItems.count; i++) {
        StandardHomeItem *temp = self.arrayItems[i];
        index = temp.isDisplay ? index + 1 : index;
        if (index == indexPath.row) {
            selectedItem = temp;
            break;
        }
    }
    if (!selectedItem) {
        return;
    }
    switch (selectedItem.type) {
        case StandardHomeTypeBodyMeasurement: {
            BodyMeasurementDetailViewController *controllerBodyMeasurement = [[BodyMeasurementDetailViewController alloc] initWithNibName:NSStringFromClass([BodyMeasurementDetailViewController class]) bundle:nil];
            [self.navigationController pushViewController:controllerBodyMeasurement animated:YES];
        }
            break;
            
        case StandardHomeTypeFitness: {
            StandardFitnessDetailViewController *controllerFitness = [[StandardFitnessDetailViewController alloc] initWithNibName:NSStringFromClass([StandardFitnessDetailViewController class]) bundle:nil];
            [self.navigationController pushViewController:controllerFitness animated:YES];
        }
            break;
        case StandardHomeTypeFood: {
            StandardFoodDetailViewController *controllerLifeStyle = [[StandardFoodDetailViewController alloc] initWithNibName:NSStringFromClass([StandardFoodDetailViewController class]) bundle:nil];
            controllerLifeStyle.type = PHRGroupTypeFood;
            [self.navigationController pushViewController:controllerLifeStyle animated:YES];
        }
            break;
        case StandardHomeTypeMedicine: {
            MedicineViewController *controllerMedicine = [[MedicineViewController alloc] initWithNibName:NSStringFromClass([MedicineViewController class]) bundle:nil];
            controllerMedicine.type = PHRGroupTypeStandard;
            [self.navigationController pushViewController:controllerMedicine animated:YES];
        }
            break;
        case StandardHomeTypeHealthRecord: {
            HealthRecordViewController *controllerBabyMedicine = [[HealthRecordViewController alloc] initWithNibName:NSStringFromClass([HealthRecordViewController class]) bundle:nil];
            [self.navigationController pushViewController:controllerBabyMedicine animated:YES];
        }
            break;
        case StandardHomeTypeTemprature: {
            StandardVitalsDetailViewController *controllerTemperature = [[StandardVitalsDetailViewController alloc] initWithNibName:NSStringFromClass([StandardVitalsDetailViewController class]) bundle:nil];
            controllerTemperature.type = PHRGroupTypeTemperature;
            [self.navigationController pushViewController:controllerTemperature animated:YES];
        }
            break;
        case StandardHomeTypeLifeStyle: {
            PHRLifeStyleNoteViewController *controllerLifeStyle = [[PHRLifeStyleNoteViewController alloc] initWithNibName:NSStringFromClass([PHRLifeStyleNoteViewController class]) bundle:nil];
            controllerLifeStyle.type = PHRGroupTypeLifeStyleNote;
            [self.navigationController pushViewController:controllerLifeStyle animated:YES];
        }
            break;
        case StandardHomeTypeMovieTalk: {
            PatientClinicViewController *controller = [[PatientClinicViewController alloc] initWithNibName:NSStringFromClass([PatientClinicViewController class])
                                                                                                                 bundle:nil];
            [self.navigationController pushViewController:controller animated:YES];
            [self.navigationController setNavigationBarHidden:NO];
        }
            break;
        default:
            break;
    }
}

#pragma mark - Action To Show Propertys


- (void)updateItemOfCollectionView:(NSNotification *)notification {
    if (![[notification name] isEqualToString:SelectedPropertyInStandard]) {
        return;
    }
    StandardItemSelected *objSelected = (StandardItemSelected *)notification.object;
    StandardHomeItem *item = [self homeItemWithType:objSelected.type];
    if (objSelected.isSelected) {
        // hide
        item.isDisplay = NO;
        Setting *setting = [[DataManager sharedManager] findSettingItemWithType:objSelected.type andUsername:PHRAppStatus.email];
        if (!setting) {
            setting = [Setting create];
        }
        setting.username = PHRAppStatus.email;
        setting.itemType = objSelected.type;
        setting.display = NO;
        [setting save];
    }
    else {
        item.isDisplay = YES;
        Setting *setting = [[DataManager sharedManager] findSettingItemWithType:objSelected.type andUsername:PHRAppStatus.email];
        if (!setting) {
            setting = [Setting create];
        }
        setting.username = PHRAppStatus.email;
        setting.itemType = objSelected.type;
        setting.display = YES;
        [setting save];
    }
    [self.collectionViewStandard reloadData];
}

- (void)dealloc {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (IBAction)actionChangeToBabyMode:(id)sender {
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyDashboardChangeTabbarIndex object:@(1)];
}



@end
