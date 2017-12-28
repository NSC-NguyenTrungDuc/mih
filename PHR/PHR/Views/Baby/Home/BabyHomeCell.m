//
//  BabyHomeMilkCell.m
//  PHR
//
//  Created by Luong Le Hoang on 10/7/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "BabyHomeCell.h"
#import "HomeMilkCell.h"
#import "BabyHomeDiaperCell.h"
#import "BabyMedicineCell.h"

static NSString *const cellMilk     = @"CellMilk";
static NSString *const cellMedicine = @"CellMedicine";
static NSString *const cellDiaper   = @"CellDiaper";

@implementation BabyHomeCell

- (void)awakeFromNib {
    // Initialization code
    // Time circle
//    self.viewTime.layer.cornerRadius = self.viewTime.frame.size.width/2;
//    self.viewTime.layer.borderWidth = 0.5f;
//    self.viewTime.layer.borderColor = [UIColor whiteColor].CGColor;
    
    // Content
//    [self.imageContentBkg setImage:[[UIImage imageNamed:@"baby_home_cell_bound"] stretchableImageWithLeftCapWidth:40 topCapHeight:40]];
//    [self.imageContentBkg setClipsToBounds:YES];
    
    // Register cell
    [self.tableContent setDelegate:self];
    [self.tableContent setDataSource:self];
    
    [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([HomeMilkCell class]) bundle:nil] forCellReuseIdentifier:cellMilk];
    [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([BabyHomeDiaperCell class]) bundle:nil] forCellReuseIdentifier:cellDiaper];
    [self.tableContent registerNib:[UINib nibWithNibName:NSStringFromClass([BabyMedicineCell class]) bundle:nil] forCellReuseIdentifier:cellMedicine];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
    
    // Configure the view for the selected state
}

- (void)setupViewContentWithType:(PHRBabyGroupType)type andModel:(id)model andShowSymbol:(BOOL)isShow {
    
    self.babyModel = model;
    
    self.viewContent.layer.borderWidth = 1;
    self.viewContent.layer.cornerRadius = 6;

    if (type == PHRBabyGroupTypeMilk) {
        [self.labelAMPM setTextColor:PHR_COLOR_DATE_TIME];
        [self.labelHour setTextColor:PHR_COLOR_DATE_TIME];
        
        self.type = PHRBabyGroupTypeMilk;
        self.viewContent.layer.borderColor = [UIColor colorWithRed:0.0 green:198.0/255.0 blue:1.0 alpha:1.0].CGColor;
        self.viewContent.backgroundColor = [UIColor colorWithRed:0.0 green:198.0/255.0 blue:1.0 alpha:0.1];
        self.imageMenutype.image = [UIImage imageNamed:@"Icon_Baby_Milk"];
        self.lblDateTimeRecord.text = kLocalizedString(kTitleMilk);
    }
    
    if (type == PHRBabyGroupTypeDiaper) {
        self.type = PHRBabyGroupTypeDiaper;
        self.viewContent.layer.borderColor = [UIColor colorWithRed:1.0 green:192.0/255.0 blue:0 alpha:1.0].CGColor;
        self.viewContent.backgroundColor = [UIColor colorWithRed:1.0 green:192.0/255.0 blue:0.0 alpha:0.1];
        self.imageMenutype.image = [UIImage imageNamed:@"Icon_Baby_Diaper"];
        self.lblDateTimeRecord.text = kLocalizedString(kBabyTitleDiaper);
    }
    
    if (type == PHRBabyGroupTypeSleep) {
        self.type = PHRBabyGroupTypeSleep;
        self.viewContent.layer.borderColor = [UIColor colorWithRed:206.0/255.0 green:120.0/255.0 blue:1.0 alpha:1.0].CGColor;
        self.viewContent.backgroundColor = [UIColor colorWithRed:206.0/255.0 green:120.0/255.0 blue:1.0 alpha:0.1];
        self.imageMenutype.image = [UIImage imageNamed:@"Icon_Baby_Sleep"];
        self.lblDateTimeRecord.text = kLocalizedString(kBabyTitleSleep);
    }
    
    if (type == PHRBabyGroupTypeGrowth) {
        self.type = PHRBabyGroupTypeGrowth;
        self.viewContent.layer.borderColor = [UIColor colorWithRed:75.0/255.0 green:181.0/255.0 blue:73.0/255.0 alpha:1.0].CGColor;
        self.viewContent.backgroundColor = [UIColor colorWithRed:75.0/255.0 green:181.0/255.0 blue:73.0/255.0 alpha:0.1];
        self.imageMenutype.image = [UIImage imageNamed:@"Icon_Baby_GrowthTL"];
        self.lblDateTimeRecord.text = kLocalizedString(kBabyTitleGrowth);
    }
    
    if (type == PHRBabyGroupTypeFood) {
        self.type = PHRBabyGroupTypeFood;
        self.viewContent.layer.borderColor = [UIColor colorWithRed:247.0/255.0 green:146.0/255.0 blue:30.0/255.0 alpha:1.0].CGColor;
        self.viewContent.backgroundColor = [UIColor colorWithRed:247.0/255.0 green:146.0/255.0 blue:30.0/255.0 alpha:0.1];
        self.imageMenutype.image = [UIImage imageNamed:@"Icon_Baby_FoodTL"];
        self.lblDateTimeRecord.text = kLocalizedString(kBabyTitleFood);
        
    }
    
    if (type == PHRBabyGroupTypeMedicine) {
        self.type = PHRBabyGroupTypeMedicine;
        self.viewContent.layer.borderColor = [UIColor colorWithRed:238.0/255.0 green:144.0/255.0 blue:125.0/255.0 alpha:1.0].CGColor;
        self.viewContent.backgroundColor = [UIColor colorWithRed:238.0/255.0 green:144.0/255.0 blue:125.0/255.0 alpha:0.1];
        self.imageMenutype.image = [UIImage imageNamed:@"Icon_Baby_Medicine"];
        self.lblDateTimeRecord.text = kLocalizedString(kBabyTitleMedicine);
        
    }
    
    [self.tableContent reloadData];
}

#pragma mark - UI Action
// UI Action
- (IBAction)actionClickIcon:(id)sender {
    if (self.actionQuickFilter) {
        self.actionQuickFilter(self);
    }
}

#pragma mark - UITableView delegate

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    NSMutableArray *arr = self.babyModel;
    return [arr count];
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    if (self.type == PHRBabyGroupTypeMilk) {
        return 75;
    }
    else if (self.type == PHRBabyGroupTypeFood){
        return 75 ;
    }
    else if (self.type == PHRBabyGroupTypeDiaper) {
        return 70;
    }
    else if (self.type == PHRBabyGroupTypeMedicine) {
        return 80;
    }
    else if (self.type == PHRBabyGroupTypeGrowth) {
        return 65;
    }
    else if (self.type == PHRBabyGroupTypeSleep) {
        return 85;
    }
    return 0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    if (self.type == PHRBabyGroupTypeMilk) {
        BabyMilkModel *babyModel = [(NSMutableArray *)self.babyModel objectAtIndex:indexPath.row];
        
        HomeMilkCell *cell = (HomeMilkCell*)[tableView dequeueReusableCellWithIdentifier:cellMilk];
        
        [cell.imgIcon1 setImage:[UIImage imageNamed:@"icon_mother_milk_white"]];
        [cell.imgIcon2 setImage:[UIImage imageNamed:@"icon_bottle_milk_white"]];
        [cell.imgIcon3 setImage:[UIImage imageNamed:@"icon_cup_white"]];
        
        [cell.label1 setText:[NSString stringWithFormat:@"%@", kLocalizedString(kTitleMotherMilk)]];
        [cell.label2 setText:[NSString stringWithFormat:@"%@", kLocalizedString(kTitleBottleMilk)]];
        [cell.label3 setText:[NSString stringWithFormat:@"%@", kLocalizedString(kTitleFeedTime)]];
        
        [cell.labelText1 setStyleRegularToLabelWithColor:[UIColor colorWithRed:0.0 green:198.0/255.0 blue:1.0 alpha:0.8] andSize:12.0];
        [cell.labeltext2 setStyleRegularToLabelWithColor:[UIColor colorWithRed:0.0 green:198.0/255.0 blue:1.0 alpha:0.8] andSize:12.0];
        [cell.labeltext3 setStyleRegularToLabelWithColor:[UIColor colorWithRed:0.0 green:198.0/255.0 blue:1.0 alpha:0.8] andSize:12.0];
        
        int method = [babyModel.drink_method intValue];
        if (method == 0) {
            [cell.labelText1 setText:[self parseTotalMinutesToTime:[babyModel.breast_time intValue]]];
            [cell.labeltext2 setText:PHR_STR_NULL];
        }
        else {
            [cell.labelText1 setText:PHR_STR_NULL];
            [cell.labeltext2 setText:[NSString stringWithFormat:@"%@ ml", babyModel.bottle_milk_volume]];
        }
        [cell.labeltext3 setText:[UIUtils formatTimeGetHoursMinutes:[UIUtils dateFromServerTimeString:babyModel.time_drink_milk]]];
        
        return cell;
    }
    if (self.type == PHRBabyGroupTypeSleep) {
        BabySleepModel *babyModel = [(NSMutableArray *)self.babyModel objectAtIndex:indexPath.row];
        HomeMilkCell *cell = (HomeMilkCell*)[tableView dequeueReusableCellWithIdentifier:cellMilk];
        
        [cell.imgIcon1 setImage:[UIImage imageNamed:PHR_ICON_MORNING]];
        [cell.imgIcon2 setImage:[UIImage imageNamed:PHR_ICON_AFTERNOON]];
        [cell.imgIcon3 setImage:[UIImage imageNamed:PHR_ICON_NIGHT]];
        
        [cell.label1 setText:[NSString stringWithFormat:@"%@", kLocalizedString(kMorning)]];
        [cell.label2 setText:[NSString stringWithFormat:@"%@", kLocalizedString(kAfternoon)]];
        [cell.label3 setText:[NSString stringWithFormat:@"%@", kLocalizedString(kNight)]];
        
        [cell.labelText1 setText:[self parseTotalMinutesToTime:[babyModel.morning_time_sleep intValue]]];
        [cell.labeltext2 setText:[self parseTotalMinutesToTime:[babyModel.afternoon_time_sleep intValue]]];
        [cell.labeltext3 setText:[self parseTotalMinutesToTime:[babyModel.night_time_sleep intValue]]];
        
        return cell;
    }
    if (self.type == PHRBabyGroupTypeDiaper) {
        BabyDiaperModel *babyModel = [(NSMutableArray *)self.babyModel objectAtIndex:indexPath.row];
        BabyHomeDiaperCell *cell = (BabyHomeDiaperCell*)[tableView dequeueReusableCellWithIdentifier:cellDiaper];
        
        if ([babyModel.method isEqualToString:@"Poo"] || [babyModel.method isEqualToString:@"うんち"]) {
            [cell.labelDiaperState setText:babyModel.state];
            [cell.labelTime setStyleRegularToLabelWithColor:[UIColor colorWithRed:255.0/255.0 green:245.0/255.0 blue:181.0/255.0 alpha:0.8] andSize:12.0];
            
            [cell.labelTime setText:[UIUtils formatTimeGetHoursMinutes:[UIUtils dateFromServerTimeString:babyModel.time_pee_poo]]];
            [cell.imagePooPee setImage:[UIImage imageNamed:@"icon_poo"]];
            [cell.imageDiaperColor setHidden:NO];
            [cell.imageDiaperColor.layer setBorderColor:[UIUtils colorFromHexString:babyModel.color].CGColor];
        }
        else {
            [cell.imageDiaperColor setHidden:YES];
            [cell.labelDiaperState setText:PHR_STR_NULL];
            [cell.labelTime setStyleRegularToLabelWithColor:[UIColor colorWithRed:42.0/255.0 green:197.0/255.0 blue:115.0/255.0 alpha:0.8] andSize:12.0];
            [cell.labelTime setText:[UIUtils formatTimeGetHoursMinutes:[UIUtils dateFromServerTimeString:babyModel.time_pee_poo]]];
            [cell.imagePooPee setImage:[UIImage imageNamed:@"icon_pee"]];
        }        
        return cell;
    }
    
    if (self.type == PHRBabyGroupTypeFood) {
        BabyFoodModel *babyModel = [(NSMutableArray *)self.babyModel objectAtIndex:indexPath.row];
        BabyHomeDiaperCell *cell = (BabyHomeDiaperCell*)[tableView dequeueReusableCellWithIdentifier:cellDiaper];
        [cell.imageDiaperColor setHidden:true];
        [cell.labelDiaperState setText:[NSString stringWithFormat:@"%@", kLocalizedString(kUnitCal)]];
        [cell.labelTime setText:[NSString stringWithFormat:@"%0.0f", [babyModel.calories doubleValue]]];
        [cell.imagePooPee setImage:[UIImage imageNamed:@"Icon_Baby_Food"]];
        
        return cell;
    }
    if (self.type == PHRBabyGroupTypeGrowth) {
        BabyGrowthModel *babyModel = [(NSMutableArray *)self.babyModel objectAtIndex:indexPath.row];
        
        BabyHomeDiaperCell *cell = (BabyHomeDiaperCell*)[tableView dequeueReusableCellWithIdentifier:cellDiaper];
        [cell.imageDiaperColor setHidden:true];
        if (babyModel.height != nil) {
            [cell.labelDiaperState setText:[NSString stringWithFormat:@"%@", kLocalizedString(kPHHeightUnit)]];
            [cell.labelTime setText:[NSString stringWithFormat:@"%0.1f", [babyModel.height doubleValue]]];
           
            [cell.imagePooPee setImage:[UIImage imageNamed:@"Icon_Baby_Height"]];
        }
        else {
            [cell.labelDiaperState setText:[NSString stringWithFormat:@"%@", kLocalizedString(kPHWeightUnit)]];
            [cell.labelTime setText:[NSString stringWithFormat:@"%0.1f", [babyModel.weight doubleValue]]];
            [cell.imagePooPee setImage:[UIImage imageNamed:@"Icon_BabyWeight"]];
        }
        
        return cell;
    }
    if (self.type == PHRBabyGroupTypeMedicine) {
        BabyMedicineModel *babyModel = [(NSMutableArray *)self.babyModel objectAtIndex:indexPath.row];
        BabyMedicineCell *cell = (BabyMedicineCell*)[tableView dequeueReusableCellWithIdentifier:cellMedicine];
        [cell setBackgroundColor:[UIColor clearColor]];
        
        [cell.lbNameMedicine setText:babyModel.name];
        [cell.lbTimeDrink setText:[UIUtils formatTimeGetHoursMinutes:[UIUtils dateFromServerTimeString:babyModel.time_take_medicine]]];
        [cell.lbNumberMedicine setText:babyModel.quantity];
        
        int methodValue = [babyModel.method intValue];
        switch (methodValue) {
            case 0:
                [cell.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine"]];
                break;
            case 1:
                [cell.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_2"]];
                break;
            case 2:
                [cell.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_3"]];
                break;
            case 3:
                [cell.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_4"]];
                break;
            case 4:
                [cell.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_5"]];
                break;
            case 5:
                [cell.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_6"]];
                break;
            case 6:
                [cell.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_7"]];
                break;
            default:
                break;
        }
        
        return cell;
    }
    return nil;
}

- (NSString *)parseTotalMinutesToTime:(int)totalMinutes {
    int hours = totalMinutes / 60;
    int minutes = totalMinutes - 60 * hours;
    NSString *strTime = [NSString stringWithFormat:@"%d:%d'", hours, minutes];
    
    return strTime;
}

@end
