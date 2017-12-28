package nta.med.service.integration.cpls;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class CPL0106U00SaveLayoutTest extends MessageRequestTest {

    @Test
    public void testCPL0106U00SaveLayoutTest() throws InterruptedException {

    	CplsModelProto.CPL0106U00GrdListItemInfo.Builder item = CplsModelProto.CPL0106U00GrdListItemInfo.newBuilder();
    	item.setHangmogCode("050925");
        item.setSpecimenCode("B23");
        item.setEmergency("N");
        item.setSubHangmogCode("B65875");
        item.setSubSpecimenCode("B23");
        item.setEmergency("N");
        item.setRowState("Added");

        List<CplsModelProto.CPL0106U00GrdListItemInfo> dts =
                new ArrayList<CplsModelProto.CPL0106U00GrdListItemInfo>();
        dts.add(item.build());
        
        CplsServiceProto.CPL0106U00SaveLayoutRequest request = CplsServiceProto.CPL0106U00SaveLayoutRequest
                .newBuilder()
             //   .setUserId("343ADM")
                .addAllInputList(dts).build();

        sentRequestToMedApp(request, CplsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));


    }
}
