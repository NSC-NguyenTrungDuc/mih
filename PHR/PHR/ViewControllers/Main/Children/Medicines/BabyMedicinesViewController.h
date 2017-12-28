//
//  BabyMedicinesViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 10/7/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface BabyMedicinesViewController : Base2ViewController

@property (weak, nonatomic) IBOutlet UIView *viewMedicines;
@property (weak, nonatomic) IBOutlet UITableView *tableViewMedicines;
@property (weak, nonatomic) IBOutlet UIImageView *BG_TableView;

@property (nonatomic) NSMutableArray *arrayDateTime;
@property (nonatomic) NSMutableArray *arrayMedicine;
@property (nonatomic) NSMutableArray *arrayDiseaes;
@property (nonatomic) NSMutableIndexSet *expandedSections;

@end
