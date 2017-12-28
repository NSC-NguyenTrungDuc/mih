//
//  DiseasesListViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 5/31/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "DiseasesViewController.h"

@interface DiseasesListViewController : Base2ViewController <UITableViewDelegate, UITableViewDataSource>


@property (weak, nonatomic) IBOutlet UITableView *tableDiseases;

@property (weak, nonatomic) IBOutlet UIView *viewEmpty;
@property (nonatomic, strong) NSMutableArray *arrayDiseaes;
@property (nonatomic, copy) void(^openDiseasesViewController)(DiseasesViewController *controller);
- (void)setListDiseases:(NSArray*)diseasesList;
- (void)reloadTableData;
@end
