//
//  TagTableViewCell.m
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "TagTableViewCell.h"

@implementation TagTableViewCell{
    EMRPlan *_emr;
}

- (void)awakeFromNib {
    [super awakeFromNib];
    // Initialization code
    self.contentView.backgroundColor  = [PHRUIColor colorProgressCourseTableCellWithAlpha:1.0];
//    self.viewKey.layer.borderColor = [UIColor grayColor].CGColor;
//    self.viewKey.layer.borderWidth = 0.2;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
    
    // Configure the view for the selected state
}

- (void)setupCellWithData:(EMRPlan*)emr{
    _emr = emr;
    self.labelKey.text = emr.tagName;
    self.labelValue.text = emr.tagContent;
    if (emr.tagType == EMRTagTypePhoto || emr.tagType == EMRTagTypePdf) {
        self.labelValue.textColor = [UIColor blueColor];
    }
}

- (IBAction)actionShow:(id)sender {
    if(self.actionOpenTagUrl){
        self.actionOpenTagUrl(_emr);
    }
}
@end
