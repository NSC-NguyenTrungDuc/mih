//
//  ChildrenMedicinesViewController.h
//  PHR
//
//  Created by BillyMobile on 6/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "PresciptionObject.h"

@protocol ChildrenMedicinesViewControllerDelegate <NSObject>
- (void)scrollToIndex:(NSInteger)index;
@end

@interface ChildrenMedicinesViewController : Base2ViewController<UITableViewDataSource,UITableViewDelegate>

@property (weak, nonatomic) IBOutlet UIView *viewEmpty;
@property (nonatomic) NSMutableArray *arrayPrescription;
@property (weak, nonatomic) IBOutlet UITableView *medicineTableView;
@property (weak, nonatomic) IBOutlet UIView *viewTabbar;
@property (weak, nonatomic) IBOutlet UILabel *lblPrescriptionList;
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;

@property (weak, nonatomic) IBOutlet UIView *viewAdd;
@property (weak, nonatomic) IBOutlet UILabel *lblAddData;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicator;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTableAndAdd;

- (IBAction)actionAddData:(id)sender;
@end
