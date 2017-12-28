package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INPORDERTRANSGrdOCS2003Test extends MessageRequestTest{

	@Test
	public void test () throws Exception {
		InpsServiceProto.INPORDERTRANSGrdOCS2003Request request = InpsServiceProto.INPORDERTRANSGrdOCS2003Request.newBuilder()
				.setSendYn("N")
				.setPkinp3010("")
				.setActingDate("2016/12/15")
				.setBunho("000114117")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
