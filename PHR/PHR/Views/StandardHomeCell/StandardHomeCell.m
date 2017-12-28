//
//  StandardHomeCell.m
//  PHR
//
//  Created by Luong Le Hoang on 10/2/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "StandardHomeCell.h"
#import "NSString+Extension.h"
#import "MasterDataManager.h"

#define IMGDashBoardHealth              @"icon_dashboard_heath"
#define IMGDashBoardFoods               @"icon_dashboard_foods"
#define IMGDashBoardMedicine            @"icon_dashboard_medicine"
#define IMGDashBoardProgress            @"icon_dashboard_progress"
#define IMGDashBoardInjuries            @"icon_dashboard_Injuries"
#define IMGDashBoardPhysiology          @"icon_dashboard_physiology"
#define IMGDashBoardSleep               @"icon_dashboard_sleep"
#define IMGDashBoardDiagnosis           @"icon_dashboard_diagnosis"
#define IMGDashBoardFitness             @"icon_dashboard_fitness"
#define IMGDashBoardMovieTalk           @"icon_dashboard_movie_talk"

@implementation StandardHomeCell{
    
}

- (void)awakeFromNib {
    
    // Circular
    self.circularView.wrapperArcWidth = 1.8f;
    self.circularView.progressArcWidth = 2.f;
    
    self.circularView.progressColor = [UIColor clearColor];
    
}

- (void)layoutSubviews{
    [super layoutSubviews];
}

- (void)fillData:(StandardHomeItem *)item{
    self.labelTitle.text = item.name;
    BOOL showInfo = (item.contentDisplay && ![item.contentDisplay isEqualToString:@""]);
    self.labelProgress.text = showInfo ? item.contentDisplay : @""; // [NSString stringWithFormat:@"%@", [[NSNumber numberWithFloat:item.progress] stringValue]] : @"";
    // Body content
    if (showInfo) {
        [self.labelIconPercent setText:@"%"];
        self.constraintIconPercentHeight.constant = item.isPercent ? 8 : 0;
        self.labelUnit.text = item.subUnit;
        CGSize sizeUnit = item.subUnit ? [UIUtils sizeForString:item.subUnit andFont:self.labelUnit.font] : CGSizeMake(0, 0);
        CGSize sizePercent = item.isPercent ? [UIUtils sizeForString:@"%" andFont:self.labelUnit.font] : CGSizeMake(0, 0);
        self.constraintLabelPercentCenter.constant = MAX(sizeUnit.width, sizePercent.width)/2;
    }
    else{
        [self.labelUnit setText:@""];
        [self.labelIconPercent setText:@""];
    }
    
    // Circular
    self.circularView.wrapperArcWidth = 1.8f;
    self.circularView.progressArcWidth = 2.f;
    [self.circularView setProgress:item.progress animated:NO];
    self.circularView.wrapperColor = [UIColor colorWithRed:0.5f green:0.5f blue:0.5f alpha:0.4f];
    switch (item.type) {
        case StandardHomeTypeBodyMeasurement:
            self.circularView.progressColor = PHR_COLOR_LIGHT_BLUE;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardHealth]];
            break;
        case StandardHomeTypeFood:
            self.circularView.progressColor = PHR_COLOR_YELLOW;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardFoods]];
            break;
        case StandardHomeTypeMedicine:
            self.circularView.progressColor = PHR_COLOR_GREEN;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardMedicine]];
            break;
        case StandardHomeTypeCourseNote:
            self.circularView.progressColor = PHR_COLOR_PURPLE;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardProgress]];
            break;
        case StandardHomeTypeHealthRecord:
            self.circularView.progressColor = PHR_COLOR_ORANGE;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardInjuries]];
            break;
        case StandardHomeTypeTemprature:
            self.circularView.progressColor = PHR_COLOR_LIGHT_GREEN;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardPhysiology]];
            break;
        case StandardHomeTypeLifeStyle:
            self.circularView.progressColor = PHR_COLOR_VIOLET;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardSleep]];
            break;
        case StandardHomeTypeFitness:
            self.circularView.progressColor = PHR_COLOR_LIGHT_SOIL;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardFitness]];
            break;
        case StandardHomeTypeMovieTalk:
            self.circularView.progressColor = PHR_COLOR_MOVIE_TALK_BLUE;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardMovieTalk]];
            break;
        default:
            self.circularView.progressColor = PHR_COLOR_MOVIE_TALK_BLUE;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardMovieTalk]];
            break;
    }
}

- (void)fillHomeItem:(StandardHomeItem *)item{
    DLog(@"BLACK BLACK BLACK --> item type = %d - situation = %d", (int)item.type, (int)item.situation);
    self.labelTitle.text = item.name;
    BOOL showInfo = (item.contentDisplay && ![item.contentDisplay isEqualToString:@""]);
   // self.labelProgress.text = showInfo ? item.contentDisplay : @"";
     self.labelProgress.text = @"";
    // Body content
    if (showInfo) {
        [self.labelIconPercent setText:@"%"];
        self.constraintIconPercentHeight.constant = item.isPercent ? 8 : 0;
        self.labelUnit.text = item.subUnit;
        CGSize sizeUnit = item.subUnit ? [UIUtils sizeForString:item.subUnit andFont:self.labelUnit.font] : CGSizeMake(0, 0);
        CGSize sizePercent = item.isPercent ? [UIUtils sizeForString:@"%" andFont:self.labelUnit.font] : CGSizeMake(0, 0);
        self.constraintLabelPercentCenter.constant = MAX(sizeUnit.width, sizePercent.width)/2;
    }
    else {
        [self.labelUnit setText:@""];
        [self.labelIconPercent setText:@""];
    }
    
    // wrapper color
    self.circularView.wrapperColor = RGBACOLOR(104., 200., 55., 0.8);
    // progress color
//    self.circularView.progressColor = [UIColor clearColor];
//    if (item.situation == MasterDataRateWarning) {
//        self.circularView.progressColor = PHR_COLOR_ORANGE;
//    }
//    else if (item.situation == MasterDataRateSerious){
//        self.circularView.progressColor = [UIColor redColor];
//    }

    // icon

    switch (item.type) {
        case StandardHomeTypeBodyMeasurement:
             self.circularView.progressColor = PHR_COLOR_DASHBOARD_BODY_MEASUREMENT;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardHealth]];
            break;
        case StandardHomeTypeFood:
            self.circularView.progressColor = PHR_COLOR_DASHBOARD_FOOD;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardFoods]];
            break;
        case StandardHomeTypeMedicine:
            self.circularView.progressColor = PHR_COLOR_DASHBOARD_MEDICINE;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardMedicine]];
            break;
        case StandardHomeTypeCourseNote:
            self.circularView.progressColor = PHR_COLOR_DASHBOARD_BODY_MEASUREMENT;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardProgress]];
            break;
        case StandardHomeTypeHealthRecord:
            self.circularView.progressColor = PHR_COLOR_DASHBOARD_HEALTH_RECORD;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardInjuries]];
            break;
        case StandardHomeTypeTemprature:
             self.circularView.progressColor = PHR_COLOR_DASHBOARD_VITALS;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardPhysiology]];
            break;
        case StandardHomeTypeLifeStyle:
            self.circularView.progressColor = PHR_COLOR_DASHBOARD_LIFE_STYLE;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardSleep]];
            break;
        case StandardHomeTypeFitness:
             self.circularView.progressColor = PHR_COLOR_DASHBOARD_FITNESS;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardFitness]];
            break;
        case StandardHomeTypeMovieTalk:
            self.circularView.progressColor = PHR_COLOR_MOVIE_TALK_BLUE;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardMovieTalk]];
        default:
            self.circularView.progressColor = PHR_COLOR_MOVIE_TALK_BLUE;
            [self.imageIcon setImage:[UIImage imageNamed:IMGDashBoardMovieTalk]];
            break;
    }

    [self.circularView setProgress:100 animated:NO];
}

@end

