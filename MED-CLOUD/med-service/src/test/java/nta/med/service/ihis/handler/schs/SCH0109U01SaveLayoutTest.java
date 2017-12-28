package nta.med.service.ihis.handler.schs;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class SCH0109U01SaveLayoutTest extends MessageRequestTest {

    @Test
    public void testSCH0109U01SaveLayoutTest() throws InterruptedException {

    	SchsModelProto.SCH0109U01GrdDetailInfo.Builder item = SchsModelProto.SCH0109U01GrdDetailInfo.newBuilder();
    	item.setCodeType("GROUP");
    	item.setCode("BAT");
    	item.setCode2("BAT");
        item.setRowState("Added");
        List<SchsModelProto.SCH0109U01GrdDetailInfo> dts =
                new ArrayList<SchsModelProto.SCH0109U01GrdDetailInfo>();
        dts.add(item.build());
        
        SchsServiceProto.SCH0109U01SaveLayoutRequest request = SchsServiceProto.SCH0109U01SaveLayoutRequest
                .newBuilder()
                .setUserId("323ADM")
                .addAllGrdDetailItem(dts).build();

        sentRequestToMedApp(request, SchsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));

    }
}
