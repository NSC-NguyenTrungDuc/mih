package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP2001U02grdOcs1003Test extends MessageRequestTest {
	@Test
	public void test () throws Exception{
	InpsServiceProto.INP2001U02grdOcs1003Request request = InpsServiceProto.INP2001U02grdOcs1003Request.newBuilder()
			.setBunho("000000001")
			.setJubsuGubun("Q")
			.setIpWonDate("2016/03/21")
			.setKaikeiYn("Y")
			.setPkOut1001("1960")
			.setOffset("100")
			.setPageNumber("1")
			.build();
	sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
