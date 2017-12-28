//
//  DiseasesViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 10/4/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface DiseasesViewController : Base2ViewController

@property (weak, nonatomic) IBOutlet UIButton *btnUploadFile;
@property (weak, nonatomic) IBOutlet DALinedTextView *noteDiseasesVC;

@property (weak, nonatomic) IBOutlet UILabel *labelTitleHospital;
@property (weak, nonatomic) IBOutlet UILabel *labelDiseasesName;
@property (weak, nonatomic) IBOutlet UILabel *labelOutCome;

@property (weak, nonatomic) IBOutlet PHRTextField *txtHospital;
@property (weak, nonatomic) IBOutlet PHRTextField *txtStatus;

@property (weak, nonatomic) IBOutlet PHRDateTimeView *dateTimeRecord;

@property (weak, nonatomic) IBOutlet PHRDateTimeView *dateTimeDiseasesBegin;
@property (weak, nonatomic) IBOutlet PHRDateTimeView *dateTimeDiseasesEnd;

@property (weak, nonatomic) IBOutlet PHRTextField *textOutCome;

@property (weak, nonatomic) IBOutlet UILabel *lbtextEvidence;
@property (weak, nonatomic) IBOutlet PHRViewUploadFile *viewUploadFileDiseases;
@property (weak, nonatomic) IBOutlet UIImageView *backgroundImage;

@property (nonatomic, strong) NSString *id_diseases;
@property (nonatomic, strong) DiseasesModel *model;
@property (nonatomic, copy) void (^addDiseasesCallBack)(DiseasesModel* type);

@end
