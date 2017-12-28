package nta.med.service.ihis.handler.schs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class SCH0201U99BookingDetailTest extends MessageRequestTest {
    @Test
    public void testSCH0201U99BookingDetail() throws InterruptedException {

    	SchsModelProto.SCH0201U99EMRLinkInfo.Builder info = SchsModelProto.SCH0201U99EMRLinkInfo.newBuilder();
    	info.setBunho("000001901");
    	info.setHospCodeLink("K01");
    	
    	SchsServiceProto.SCH0201U99BookingDetailRequest request = SchsServiceProto.SCH0201U99BookingDetailRequest.newBuilder()
    			.setJundalTable("OP")
    			.setReservation("A")
    			.setReserDate("2016/04/06")
    			.addEmrLinkItem(info)
                .build();

        sentRequestToMedApp(request, SchsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
