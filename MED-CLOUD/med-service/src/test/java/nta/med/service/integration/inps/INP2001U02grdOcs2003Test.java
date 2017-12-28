package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP2001U02grdOcs2003Test extends MessageRequestTest{

	@Test
	public void test() throws InterruptedException{
		InpsServiceProto.INP2001U02grdOcs2003Request request = InpsServiceProto.INP2001U02grdOcs2003Request.newBuilder()
				.setBunho("000002043")
				.setFkInp1001("4063")
				.build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
