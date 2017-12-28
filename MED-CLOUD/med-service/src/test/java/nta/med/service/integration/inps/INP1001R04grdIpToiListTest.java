package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001R04grdIpToiListTest extends MessageRequestTest {
	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001R04grdIpToiListRequest request = InpsServiceProto.INP1001R04grdIpToiListRequest.newBuilder()
				.setFromDate("2013/08/02")
				.setToDate("2013/08/12")
				.setPageNumber("1")
				.setOffset("10")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}