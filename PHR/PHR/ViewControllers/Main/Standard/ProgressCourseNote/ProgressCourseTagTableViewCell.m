//
//  ProgressCourseTagTableViewCell.m
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ProgressCourseTagTableViewCell.h"
#import "EMRPlan.h"
#import "TagTableViewCell.h"

@interface ProgressCourseTagTableViewCell()
@property (nonatomic,strong) UITableView *subMenuTableView;
@end
static NSString *cellIdentifier = @"tagTableViewCell";

@implementation ProgressCourseTagTableViewCell

-(void)awakeFromNib {
    [super awakeFromNib];
    // Initialization code
    [self setupUI];
}

-(id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier {
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        _arrayEMRPlanNotes = [NSMutableArray new];
        // Initialization code
        self.frame = CGRectMake(0, 0, 300, 50);
        _subMenuTableView = [[UITableView alloc]initWithFrame:CGRectZero style:UITableViewStylePlain]; //create tableview a
        _subMenuTableView.separatorStyle = UITableViewCellSeparatorStyleNone;
        [_subMenuTableView registerNib:[UINib nibWithNibName:@"TagTableViewCell" bundle:nil] forCellReuseIdentifier:cellIdentifier];
        _subMenuTableView.tag = 100;
        _subMenuTableView.delegate = self;
        _subMenuTableView.dataSource = self;
        [self addSubview:_subMenuTableView]; // add it cell
        //[subMenuTableView release]; // for without ARC
    }
    return self;
}

-(void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
}

-(void)layoutSubviews {
    [super layoutSubviews];
    _subMenuTableView.frame = CGRectMake(5, 5, self.bounds.size.width-5, self.bounds.size.height-5);//set the frames for tableview
    [_subMenuTableView reloadData];
}

-(void)setupUI{
    [self.contentView setBackgroundColor:[PHRUIColor colorProgressCourseTableCellWithAlpha:1.0]];
}

-(void)fillData:(NSMutableArray*)arrayData{
    
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView{
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
    if (_arrayEMRPlanNotes.count > 0) {
        return _arrayEMRPlanNotes.count + 1;
    }
    return 0;
}
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    TagTableViewCell *tagCell = (TagTableViewCell*) [tableView dequeueReusableCellWithIdentifier:cellIdentifier forIndexPath:indexPath];
    NSObject *obj = [_arrayEMRPlanNotes objectAtIndex:indexPath.row];
    if ([obj isKindOfClass:[EMRPlan class]]){
        EMRPlan *emrPlan = (EMRPlan*) obj;
        tagCell.labelKey.text = emrPlan.tagName;
        tagCell.labelValue.text = emrPlan.tagContent;
    }
    return tagCell;
}


@end
