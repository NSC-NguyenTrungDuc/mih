//
//  BabyPrescriptionViewController.h
//  PHR
//
//  Created by BillyMobile on 6/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "PresciptionObject.h"

@interface BabyPrescriptionViewController : Base2ViewController<UITableViewDataSource,UITableViewDelegate>

@property (weak, nonatomic) IBOutlet UITableView *tableContent;
@property (weak, nonatomic) IBOutlet PHRDateTimeView *dateTimeView;
@property (nonatomic) NSMutableArray *arrayNotification;
@property (nonatomic) NSMutableArray *arrayDrug;
@property (weak, nonatomic) IBOutlet UILabel *lblPrescriptionName;
@property (weak, nonatomic) IBOutlet PHRTextField *txtPrescriptionName;

@property (strong, nonatomic) PresciptionObject *prescriptionItem;
@property (assign, nonatomic) BOOL isUpdate;

@property (copy, nonatomic) void (^addPrescriptionCallBack)();

@end
