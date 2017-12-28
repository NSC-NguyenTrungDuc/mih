//
//  AddNewPresciptionViewController.h
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "PresciptionObject.h"
#import "DrugNote.h"

@interface AddNewPresciptionViewController : Base2ViewController<UITableViewDataSource,UITableViewDelegate>

@property (weak, nonatomic) IBOutlet UITableView *tableContent;
@property (weak, nonatomic) IBOutlet PHRDateTimeView *dateTimeView;
@property (nonatomic, retain) PresciptionObject *data;
//@property (nonatomic) NSMutableArray *arrayNoti;
@property (nonatomic, strong) NSMutableArray *arrayNotification;
@property (nonatomic, strong) NSMutableArray *arrayDrug;
@property (weak, nonatomic) IBOutlet UILabel *lblPrescriptionName;
@property (weak, nonatomic) IBOutlet PHRTextField *txtPrescriptionName;
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;


@end
