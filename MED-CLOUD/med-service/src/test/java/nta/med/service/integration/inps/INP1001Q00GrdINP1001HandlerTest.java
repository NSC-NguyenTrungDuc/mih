package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1001Q00GrdINP1001HandlerTest extends MessageRequestTest {
	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INP1001Q00grdINP1001Request request = InpsServiceProto.INP1001Q00grdINP1001Request.newBuilder()
				.setBunho("099993001")
				.setFromDate("2013/08/02")
				.setToDate("2013/08/12")
				.setPageNumber("1")
				.setOffset("10")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
