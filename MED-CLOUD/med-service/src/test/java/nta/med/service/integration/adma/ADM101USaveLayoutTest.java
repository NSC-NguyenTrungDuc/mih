package nta.med.service.integration.adma;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.AdmaModelProto.ADM101UgrdSystemItemInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;


public class ADM101USaveLayoutTest extends MessageRequestTest {
    @Test
    public void testADM101USaveLayout() throws InterruptedException {
    	
    	List<ADM101UgrdSystemItemInfo> listInfo = new ArrayList<ADM101UgrdSystemItemInfo>();
    	
    	
    	ADM101UgrdSystemItemInfo.Builder info1 =  ADM101UgrdSystemItemInfo.newBuilder();
    	info1.setGrpId("TKG");
    	info1.setSysId("OCS5");
    	info1.setSysNm("\345\244\226\346\235\245\343\202\252\343\203\274\343\203\200");
    	info1.setSysSeq("1");
    	info1.setAdmSysYn("N");
    	info1.setMsgSysYn("N");
    	info1.setSysDesc("11");
    	info1.setDataRowState("Added");
    	listInfo.add(info1.build());
    	
    	ADM101UgrdSystemItemInfo.Builder info2 =  ADM101UgrdSystemItemInfo.newBuilder();
    	info2.setGrpId("TKG");
    	info2.setSysId("NUR5");
    	info2.setSysNm("\345\244\226\346\235\245\347\234\213\350\255\267");
    	info2.setSysSeq("2");
    	info2.setAdmSysYn("N");
    	info2.setMsgSysYn("N");
    	info2.setSysDesc("21");
    	info2.setDataRowState("Added");
    	listInfo.add(info2.build());
    	
//    	List<ADM101UGrdGroupItemInfo> listInfo3 = new ArrayList<ADM101UGrdGroupItemInfo>();
//    	ADM101UGrdGroupItemInfo.Builder info3 =  ADM101UGrdGroupItemInfo.newBuilder();
//    	info3.setGrpId("TKG");
//    	info3.setGrpNm("\343\201\237\343\201\215\343\201\220\343\201\241");
//    	info3.setGrpSeq("66");
//    	info3.setDispGrpId("AAA");
//    	info3.setDataRowState("Deleted");
//    	listInfo3.add(info3.build());
    	
    	/*ADM101UgrdSystemItemInfo.Builder info5 =  ADM101UgrdSystemItemInfo.newBuilder();
    	info5.setGrpId("TKG");
    	info5.setSysId("NUR5");
    	info5.setSysNm("\345\244\226\346\235\245\347\234\213\350\255\267");
    	info5.setSysSeq("2");
    	info5.setAdmSysYn("N");
    	info5.setMsgSysYn("N");
    	info5.setSysDesc("21");
    	info5.setDataRowState("Added");
    	listInfo3.add(info5.build());*/
    	
    	/*AdmaServiceProto.ADM101USaveLayoutRequest request = AdmaServiceProto.ADM101USaveLayoutRequest.newBuilder()
    			.setUserId("SAM001").addAllGrdSystemItem(listInfo).addAllGrdGroupItem(listInfo3).build();*/
    	
    	
    	AdmaServiceProto.ADM101USaveLayoutRequest request = AdmaServiceProto.ADM101USaveLayoutRequest.newBuilder()
    			.setUserId("SAM001").addAllGrdSystemItem(listInfo).build();
    	
        sentRequestToMedApp(request, AdmaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
