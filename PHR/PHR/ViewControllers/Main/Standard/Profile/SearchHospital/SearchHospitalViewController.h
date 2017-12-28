//
//  SearchHospitalViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "ClinicHospital.h"

@interface SearchHospitalViewController : Base2ViewController <UITableViewDataSource, UITableViewDelegate>{
    
}
@property (weak, nonatomic) IBOutlet UITextField *txtName;
@property (weak, nonatomic) IBOutlet UITextField *txtAddress;
@property (weak, nonatomic) IBOutlet UITextField *txtPhone;
@property (weak, nonatomic) IBOutlet UITextField *txtCountry;
@property (weak, nonatomic) IBOutlet UIButton *btnSearch;
@property (weak, nonatomic) IBOutlet UITableView *tableResult;
@property (weak, nonatomic) IBOutlet UIButton *btnSelectCountry;
@property (weak, nonatomic) IBOutlet UIButton *btnOk;

@property (nonatomic, copy) void(^actionSelectHospital)(ClinicHospital *hospital);

- (IBAction)actionSearch:(id)sender;
- (IBAction)actionDone:(id)sender;
- (IBAction)actionSelectCountry:(id)sender;

@end
