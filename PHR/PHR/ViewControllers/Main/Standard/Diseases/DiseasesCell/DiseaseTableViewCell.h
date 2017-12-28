//
//  DiseaseTableViewCell.h
//  PHR
//
//  Created by BillyMobile on 7/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface DiseaseTableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UILabel *lblDiseasesName;
@property (weak, nonatomic) IBOutlet UILabel *lblHospiatalName;
@property (weak, nonatomic) IBOutlet UILabel *lblDateTime;

@end
