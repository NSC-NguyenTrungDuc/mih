//
//  MedicineViewController.h
//  PHR
//
//  Created by BillyMobile on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "TodayDrugTableViewCell.h"
#import "PresciptionListTableViewCell.h"
#import "PresciptionObject.h"

@interface MedicineViewController : Base2ViewController<UITableViewDataSource,UITableViewDelegate>

@property (weak, nonatomic) IBOutlet UIView *viewEmpty;
@property (weak, nonatomic) IBOutlet UILabel *lbStatus;
@property (nonatomic) NSMutableArray *arrayPrescription;
@property (weak, nonatomic) IBOutlet UIView *viewTabbar;
@property (weak, nonatomic) IBOutlet UITableView *medicineTableView;
@property (weak, nonatomic) IBOutlet UITableView *tableViewClinic;
@property (weak, nonatomic) IBOutlet UILabel *lblPrescriptionList;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicator;

@property (weak, nonatomic) IBOutlet UIImageView *backgroundImage;
@end
