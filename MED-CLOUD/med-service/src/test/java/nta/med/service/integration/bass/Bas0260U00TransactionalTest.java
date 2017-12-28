package nta.med.service.integration.bass;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class Bas0260U00TransactionalTest extends MessageRequestTest {

    @Test
    public void testBas0260U00TransactionalTest() throws InterruptedException {

        BassModelProto.BAS0260GrdBuseoListItemInfo.Builder item = BassModelProto.BAS0260GrdBuseoListItemInfo.newBuilder();
        item.setBuseoCode("1235");
        item.setBuseoName ("BuseoName1");
        item.setParentBuseo ("Parent"); 
        item.setBuseoGubun ("1");  
        item.setOutJubsuYn ("Y"); 
        item.setIpwonYn ("Y");    
        item.setOutSlipYn ("Y"); 
        item.setInpSlipYn ("Y"); 
        item.setEuryoseoYn ("Y"); 
	    item.setOutMoveYn ("Y"); 
	    item.setOutJundalPartYn ("Y");        
	    item.setInpJundalPartYn ("Y");        
	    item.setGwaEname ("GwaE");     
	    item.setGwaSort1 ("2.0");     
	    item.setGwaSort2 ("2.0");     
	    item.setEndDate ("9998/12/31");      
	    item.setStartDate ("2015/4/16");    
	    item.setBuseoName2 ("Buseo2");   
      
        item.setRowSate("Added");

        List<BassModelProto.BAS0260GrdBuseoListItemInfo> dts =
                new ArrayList<BassModelProto.BAS0260GrdBuseoListItemInfo>();
        dts.add(item.build());
        
        BassServiceProto.Bas0260U00TransactionalRequest request = BassServiceProto.Bas0260U00TransactionalRequest
                .newBuilder()
                .setUserId("SAM001")
                .setHospCode("414")
                .addAllGrdBuseoList(dts).build();

        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));


    }
}
